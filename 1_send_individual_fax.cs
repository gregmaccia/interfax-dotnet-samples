// a path to an InterFAX
// compatible file
var file = interfax.Documents.BuildFaxDocument(@".\path\to\fax.pdf");
var options = new SendOptions {
  // a valid fax number
  FaxNumber = "+11111111112"
};

// send a single fax
var faxId = await interfax.Outbound.SendFax(
  file,
  options
);
