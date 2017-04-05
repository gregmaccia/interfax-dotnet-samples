// read the file size
var filePath = @".\path\to\fax.pdf";
var fileInfo = new FileInfo(filePath);

// start a new document upload session
var sessionId = interfax.Outbound.Documents.CreateUploadSession(
    new UploadSessionOptions
    {
        Name = fileInfo.Name,
        Size = (int) fileInfo.Length
    }
).Result;

// open the file and start the upload
using (var fileStream = File.OpenRead("test.pdf"))
{
  // prepare a buffer for each upload
  var buffer = new byte[500];
  int len;

  // read the file into the buffer
  while ((len = fileStream.Read(buffer, 0, buffer.Length)) > 0)
  {
    var data = new byte[len];
    Array.Copy(buffer, data, len);
    // upload the chunk
    var response = interfax.Outbound.Documents.UploadDocumentChunk(
      sessionId,
      fileStream.Position - len,
      data
    ).Result;
    // if the status code was accepted then we continue
    if (response.StatusCode == HttpStatusCode.Accepted) continue;
    // otherwise we are done and can send the fax
    if (response.StatusCode == HttpStatusCode.OK)
    {
      // we load the document so we can get its URI
      var document = await interfax.Documents.GetUploadSession(sessionId);
      // finally we send the fax using the document URI
      var faxId = await interfax.Outbound.SendFax(
          interfax.Documents.BuildFaxDocument(session.Uri),
          new SendOptions
          {
              FaxNumber = "+111111111112"
          }
      );
      break;
    }
  }
}
