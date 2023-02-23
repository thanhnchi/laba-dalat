var $categoryIdEl = $('#input_category_id'),
	$pageEl = $('#input_page'),
	$recordEl = $('#input_record');

const dataParms = function () {
	return {
		c: IsNullOrEmty($categoryIdEl.val()) ? null : parseInt($categoryIdEl.val()),
		page: parseInt($pageEl.val()),
		record: parseInt($recordEl.val())
	}
}

$(document).ready(function () {
	LoadListMainData();
});

//Load list main data
function LoadListMainData() {
	var data = dataParms();
	try {
		ShowOverlay("#div_main_data");
		$.ajax({
			type: 'GET',
			url: '/Services/GetList',
			data: data,
			dataType: "json",
			success: function (response) {
				HideOverlay("#div_main_data");
				if (response.result !== 1) {
					document.getElementById("div_main_data").innerHTML = ` 
                    <div class="text-center p-2">
                        <h4>Kết nối không ổn định</h4>
                        <button type="button" class="btn btn-primary" 
                            style="width:200px;height:45px;border-radius:4px;" 
                            onclick="LoadListMainData();$(this).parent().remove();">Tải lại
                        </button>
                    </div>`;
					return;
				}

				var listData = response.data;
				var tmpHtml = '';
				if (listData != null && listData.length > 0) {
					$.each(listData, function (key, value) {
						const link = "/dich-vu/" + value.titleSlug + "-" + value.id;
						tmpHtml +=
							`<article class="item post col-md-6">
							<div class="card h-100">
								<figure class="card-img-top overlay overlay-1 hover-scale">
									<a href="${link}"> <img src="${value.imageObj?.relativeUrl}" class="h-23" style="object-fit: cover" alt="${value.title}" /></a>
									<figcaption>
										<h5 class="from-top mb-0">Xem chi tiết</h5>
									</figcaption>
								</figure>
								<div class="card-body">
									<div class="post-header">
										<div class="post-category text-line">
											<a href="/dich-vu?c=${value.categoryObj?.id}" class="hover" rel="category">${value.categoryObj?.name}</a>
										</div>
										<!-- /.post-category -->
										<h2 class="post-title text-truncate-1 h3 mt-1 mb-3"><a class="link-dark" href="${link}" title="${value.title}">${value.title}</a></h2>
									</div>
									<!-- /.post-header -->
									<div class="post-content">
										<p class="text-truncate-3">${value.description}</p>
									</div>
									<!-- /.post-content -->
								</div>
								<!--/.card-body -->
							</div>
							<!-- /.card -->
						</article>`
					});
					document.getElementById("div_main_data").innerHTML = tmpHtml;
					document.getElementById("div_main_data").innerHTML = tmpHtml;
				}
				else {
					document.getElementById("div_main_data").innerHTML = `<div class="d-flex align-items-center flex-column">
                                                                            <img class="w-auto" src="./assets/img/other/empty.png"/>
                                                                            <span class="text-muted">Không có dữ liệu !</span>
                                                                        </div>`;
				}
				var totalRecord = parseInt(response.data2nd);
				var currentPage = parseInt(data.page);
				var pageSize = parseInt(data.record);
				var pagination = LoadPagination(totalRecord, pageSize, currentPage);
				$('#ul_main_pagination').html(pagination);
			},
			error: function (error) {
				HideOverlay("#div_main_data");
				document.getElementById("div_main_data").innerHTML = ` 
                    <div class="text-center p-2">
                        <i type="button" class="fa fa-refresh" 
                            style="border-radius:4px;font-size:24px;" 
                            onclick="LoadListMainData();$(this).parent().remove();">
                        </i>
                    </div>`;
			}
		});
	} catch (e) {
		HideOverlay("#div_main_data");
		document.getElementById("div_main_data").innerHTML = `
                    <div class="text-center p-2">
                        <i type="button" class="fa fa-refresh" 
                            style="border-radius:4px;font-size:24px;" 
                            onclick="LoadListMainData();$(this).parent().remove();">
                        </i>
                    </div>`;
	}
}


//When click pagination 
function ChangePageNews(page, e, elm) {
	e.preventDefault();
	ScrollToTop('#div_main_data', 70, 500);
	$pageEl.val(page);

	//Change Link
	var newHref = $(elm).attr("href");
	ChangeURLWithOut("", newHref);

	//Get List
	LoadListMainData();
}

//Load Pagination Page
function LoadPagination(totalRecords, pageSize = 12, currentPage) {
	if (totalRecords < 5) return false;

	var pageDisplay = 5;
	var totalPage = Math.ceil(totalRecords / pageSize);
	//Check currentPage error
	if (currentPage > totalPage) {
		currentPage = totalPage;
	}
	if (currentPage < 1) {
		currentPage = 1;
	}

	var startPage = parseInt(Math.max(1, Math.ceil(currentPage - pageDisplay / 2)));
	var endPage = parseInt(Math.min(totalPage, currentPage + pageDisplay / 2));

	if (totalPage >= 1) {
		var html = '';
		let link = GetLink();
		if (currentPage > 1) {
			html += `<li class="page-item">
					    <a class="page-link" href="${link}record=${pageSize}&page=${currentPage - 1}" title="Trang trước" onclick="ChangePageNews(${currentPage - 1},event,this)" aria-label="Previous">
						    <span aria-hidden="true"><i class="uil uil-arrow-left"></i></span>
					    </a>
				    </li>`;
		}
		for (var i = startPage; i <= endPage; i++) {
			if (currentPage == i) {
				html += `<li class="page-item active"><a class="page-link bg-primary text-light">${currentPage}</a></li>`;
			}
			else {
				html += `<li class="page-item">
                             <a class="page-link" href="${link}record=${pageSize}&page=${i}" onclick="ChangePageNews(${i},event,this)" title="Trang ${i}">${i}</a>
                        </li>`;
			}
		}
		if (currentPage < totalPage) {
			html += `<li class="page-item">
				        <a class="page-link" href="${link}record=${pageSize}&page=${currentPage + 1}" title="Trang kế tiếp"  onclick="ChangePageNews(${currentPage + 1},event,this)" aria-label="Next">
					        <span aria-hidden="true"><i class="uil uil-arrow-right"></i></span>
				        </a>
			        </li>`;
		}
		return html;
	}

	else {
		//NoData
		return "";
	}
}

//Get Url Link
function GetLink() {
	var str = window.location.search.substring(1);
	var res = str.split("&");
	var test = res.splice(-2, 2);
	var link = "";
	if (test[0].indexOf("record") > -1 && test[1].indexOf("page") > -1) {
		res.forEach(function (item, index) {
			link += item + "&";
		});
	}
	else {
		if (str == "") {
			link = str;
		}
		else {
			link = str + "&";
		}
	}
	return window.location.pathname + "?" + link;
}

