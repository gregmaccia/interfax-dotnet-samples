// given an InterFAX fax ID
var faxId = 12345;
// resend the email
await interfax.Inbound.Resend(faxId);
// mark as unread
await interfax.Inbound.MarkUnread(faxId);
