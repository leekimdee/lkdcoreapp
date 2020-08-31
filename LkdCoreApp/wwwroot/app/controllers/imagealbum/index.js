var imageAlbumController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //todo: binding events to controls
        $('#ddlShowPage').on('change', function () {
            lkd.configs.pageSize = $(this).val();
            lkd.configs.pageIndex = 1;
            loadData(true);
        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                //keyword: $('#txtKeyword').val(),
                keyword: '',
                page: lkd.configs.pageIndex,
                pageSize: lkd.configs.pageSize
            },
            url: '/admin/imagealbum/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                $.each(response, function (i, item) {
                    //console.log(item);
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Title: item.Title,
                        SortOrder: item.SortOrder,
                        //CreatedDate: tedu.dateTimeFormatJson(item.DateCreated),
                        Status: lkd.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(response.RowCount);
                    
                    if (render != '') {
                        $('#tbl-list').append(render);
                    }

                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
                
            },
            error: function (status) {
                console.log(status);
                lkd.notify('Cannot loading data', 'error');
            }
        })
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / lkd.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                lkd.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}