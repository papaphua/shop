﻿namespace Shop.Shared.Core.Pagination;

public sealed record PagingQuery(
    int PageNumber,
    int PageSize)
{
    public int Offset()
    {
        return (PageNumber - 1) * PageSize;
    }
}