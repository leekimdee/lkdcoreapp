var imageController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //Init validation
        //$('#frmMaintainance').validate({
        //    errorClass: 'red',
        //    ignore: [],
        //    //lang: 'vi',
        //    rules: {
        //        txtNameM: { required: true },
        //        ddlCategoryIdM: { required: true },
        //        txtPriceM: {
        //            required: true,
        //            number: true
        //        }
        //    }
        //});

        //todo: binding events to controls
        $('#ddlShowPage').on('change', function () {
            lkd.configs.pageSize = $(this).val();
            lkd.configs.pageIndex = 1;
            loadData(true);
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Image/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    lkd.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtTitleM').val(data.Title);
                    loadAlbums(data.ImageAlbumId);

                    // $('#txtImageM').val(data.ThumbnailImage);

                    $('#ckStatusM').prop('checked', data.Status == 1);

                    $('#modal-add-edit').modal('show');
                    lkd.stopLoading();

                },
                error: function (status) {
                    lkd.notify('Có lỗi xảy ra', 'error');
                    lkd.stopLoading();
                }
            });
        });
    }

    function initDropDownAlbum(selectedId) {
        $.ajax({
            url: "/Admin/ImageAlbum/GetAll",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Title,
                        sortOrder: item.SortOrder
                    });
                });
                //var arr = lkd.unflattern(data);
                //$('#ddlCategoryIdM').combotree({
                //    data: arr
                //});
                //if (selectedId != undefined) {
                //    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                //}
            }
        });
    }

    function loadAlbums(selectedId) {
        $.ajax({
            type: 'GET',
            url: '/admin/imagealbum/GetAll',
            dataType: 'json',
            success: function (response) {
                var render = "<option value=''>--Chọn album--</option>";
                $.each(response, function (i, item) {
                    if (selectedId == item.Id) {
                        render += "<option value='" + item.Id + "' selected>" + item.Title + "</option>"
                    }
                    else
                        render += "<option value='" + item.Id + "'>" + item.Title + "</option>"
                });
                $('#ddlAlbumId').html(render);
            },
            error: function (status) {
                console.log(status);
                lkd.notify('Cannot loading image album data', 'error');
            }
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
            url: '/admin/image/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Title: item.Title,
                        ImageUrl: item.ImageUrl,
                        AlbumId: item.ImageAlbum.Title,
                        //CreatedDate: tedu.dateTimeFormatJson(item.DateCreated),
                        Status: lkd.getStatus(item.Status)
                    });
                });

                $('#lblTotalRecords').text(response.RowCount);

                if (render != '') {
                    $('#tbl-content').html(render);
                }

                wrapPaging(response.RowCount, function () {
                    loadData();
                }, isPageChanged);
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