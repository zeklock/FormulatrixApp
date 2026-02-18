export interface PaginateResponseType<T> {
  items: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
}

export interface PaginateRequestType {
  page: number;
  size: number;
}
