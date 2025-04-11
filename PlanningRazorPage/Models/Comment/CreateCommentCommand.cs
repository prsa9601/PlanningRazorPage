namespace PlanningRazorPage.Models.Comment
{
    public record ChangeStatusCommentCommand(long Id, CommentStatus Status);
    public record EditCommentCommand(long CommentId, string Text, long UserId);
    public record class DeleteCommentCommand(long CommentId);
    public record CreateCommentCommand(string Text, long UserId, long ProductId);
    public enum CommentStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}