using Domain.Enums;

namespace Application.Features.AdminActions.Queries.GetById
{
    public class GetByIdAdminActionResponse
    {
        public int Id { get; set; }
        public ActionType ActionType { get; set; }
        public string ActionDescription { get; set; }
        public int AdminId { get; set; }
    }
}
