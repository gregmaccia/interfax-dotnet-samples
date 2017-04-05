// given an InterFAX fax ID
var faxId = 12345;
// retrieve the fax
var fax = await interfax.Inbound.GetFaxRecord(faxId);
// check the status
fax.MessageStatus;
// check the number of pages
fax.Pages;
