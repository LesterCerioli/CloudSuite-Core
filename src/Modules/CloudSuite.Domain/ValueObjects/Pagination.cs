
namespace CloudSuite.Domain.ValueObjects
{
    public class Pagination
    {
        private int _pageNumber;
        private int _pageSize;
        private int _totalItems;

        public int PageNumber
        {
            get => _pageNumber;
            private set
            {
                if (value < 1)
                    throw new ArgumentException("O número da página deve ser maior ou igual a 1.");
                _pageNumber = value;
            }
        }

        public int PageSize
        {
            get => _pageSize;
            private set
            {
                if (value < 1)
                    throw new ArgumentException("O tamanho da página deve ser mairo ou igual a 1.");
                _pageSize = value;
            }
        }

        public int? TotalPages => (int)Math.Ceiling((double)_totalItems / PageSize);

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public Pagination(int pageNumber, int pageSize, int totalItems)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            _totalItems = totalItems;
        }

        public void NextPage()
        {
            if (HasNextPage)
                PageNumber++;
        }

        public void PreviousPage()
        {
            if (HasPreviousPage)
                PageNumber--;
        }
    }
}
