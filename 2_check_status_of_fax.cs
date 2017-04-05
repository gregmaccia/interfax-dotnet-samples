// given an InterFAX fax ID
var faxId = 12345;
// retrieve the fax
var fax = interfax.Outbound.GetFaxRecord(faxId);
// check the status
fax.Status;
