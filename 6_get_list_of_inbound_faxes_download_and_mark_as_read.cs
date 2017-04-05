// get all unread faxes
var faxes = await interfax.Inbound.GetList(
  new ListOptions {
    UnreadOnly = false
  }
);

foreach (var fax in faxes)
{
  // save the fax image
  var image = await interfax.Inbound.GetFaxImageStream(
    fax.MessageId
  );
  var file = File.Create($".\\{fax.MessageId}.pdf");
  Utils.CopyStream(image, file);
  // mark the file as read
  interfax.Inbound.MarkRead(fax.MessageId);
}
