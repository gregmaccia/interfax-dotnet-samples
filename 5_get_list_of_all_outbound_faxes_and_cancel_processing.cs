// get all recent faxes
var faxes = await interfax.Outbound.GetList();

// cancel all processing faxes
foreach (var fax in faxes)
{
  if (fax.Status < 0)
  {
    await interfax.Outbound.CancelFax(fax.Id);
  }
}
