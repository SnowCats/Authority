interface IPagination {  
  page?: number,
  count?: number,
  itemsPerPage?: number,
};

export default class Pagination implements IPagination {
  page = 1;
  count = 0;
  itemsPerPage = 10;
}