namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Criteria<ItemToMatch>
    {
        bool is_satisfied_by(ItemToMatch item);
    }
}