// create the various documents
var file1 = interfax.Documents.BuildFaxDocument(
  @".\path\to\fax.pdf"
);
var file2 = interfax.Documents.BuildFaxDocument(
  @".\path\to\fax.html"
);
var uri1 = interfax.Documents.BuildFaxDocument(
  new Uri("http://example.com/path/to/fax.html")
);

// combine the documents to a list
var documents = new List<IFaxDocument> {
  file1, file2, uri1
};

// fax the list
await interfax.Outbound.SendFax(
  documents,
  new SendOptions {
    FaxNumber = "+11111111112"
  }
);
