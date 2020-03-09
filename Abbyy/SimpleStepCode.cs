using Abbyy.CloudSdk.V2.Client;
using Abbyy.CloudSdk.V2.Client.Models;
using Abbyy.CloudSdk.V2.Client.Models.Enums;
using Abbyy.CloudSdk.V2.Client.Models.RequestParams;
using DecisionsFramework.Design.Flow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The simplest types of steps are method based sync steps.  Simply write whatever
/// .NET code you want and use an attribute on the CLASS or on the METHOD itself to 
/// register that code with the workflow engine as a flow step.
/// </summary>
namespace Abbyy
{
    [AutoRegisterMethodsOnClass(true, "integration/Abbyy OCR")]
    public class AbbyyClass
    {
        public AuthInfo Auth(string HostURL, string ApplicationId, string Password ) 
        {
            var authInfo = new AuthInfo
            {
                Host = HostURL,
                ApplicationId = ApplicationId,
                Password = Password,
            };
            return authInfo;
        }

        public async Task<List<string>> AbbyyRunnerAsync (AuthInfo authInfo, string FilePath)
        {
            var client = new OcrClient(authInfo);
            var imageParams = new ImageProcessingParams
            {
                ExportFormats = new[] { ExportFormat.Txt },
                Language = "English", ReadBarcodes = true, CorrectOrientation = true, 
             
            };

            var fileStream = new FileStream(FilePath, FileMode.Open);
            var taskInfo = await client.ProcessImageAsync(imageParams, fileStream, Path.GetFileName(FilePath), waitTaskFinished: true);
            
            return taskInfo.ResultUrls;
        }


    }
}
