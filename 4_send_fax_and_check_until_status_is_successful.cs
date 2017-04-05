// send a fax
var faxId = await interfax.Outbound.SendFax(
  interfax.Documents.BuildFaxDocument(@".\path\to\fax.pdf"),
  new SendOptions
  {
    FaxNumber = "+11111111112"
  }
);

// wait for the fax to be
// delivered successfully
while (true)
{
  // load the fax's status
  var fax = await interfax.Outbound.GetFaxRecord(faxId);
  // sleep if pending
  if (fax.Status < 0)
  {
    Thread.Sleep(10000);
  } else if (fax.Status == 0)
  {
    Debug.WriteLine("Sent!");
    break;
  } else
  {
    Debug.WriteLine($"Error: {fax.Status}");
    break;
  }
}
