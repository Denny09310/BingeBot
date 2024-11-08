namespace Jobs.Get.Id;

internal sealed class Request
{
    public int Id { get; set; }
}

internal sealed class Response
{
    public Guid TrackingId { get; set; }
}