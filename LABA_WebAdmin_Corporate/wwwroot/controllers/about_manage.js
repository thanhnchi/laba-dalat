let laddaSubmitForm;
var $selectSearchStatus = $('#select_search_status');
var laddaSearch = Ladda.create(document.querySelector('#btn_search'));

$(document).ready(function () {
	//Init dropify upload image
	0 < $('[data-plugins="dropify"]').length && $('[data-plugins="dropify"]').dropify({
		messages: {
			default: "Chọn ảnh đại diện",
			replace: "Chọn ảnh khác",
			remove: '<i class="bx bx-trash-alt"></i>',
			error: "Ảnh không hợp lệ"
		}, tpl: {
			message: '<div class="dropify-message"><span class="bx bx-upload font-40"></span> <p class="font-14">{{ default }}</p></div>',
			clearButton: '<button type="button" class="dropify-clear btn btn-danger p-1">{{ remove }}</button>',
		}, error: { fileSize: "Kích thước tối đa " + MAX_FILE_SIZE_IMAGE + "MB." }
	});

	// Init DateTime Picker
	duDatepicker('form [name="publishedAt"]',
		{
			auto: true,
			format: 'yyyy-mm-dd',
			theme: 'indigo',
			i18n: 'vi',
		}
	);
	setTimeout(function () {
		LoadData('GET', {
			status: $selectSearchStatus.val()
		});
	}, 100)
	//Init submit form
	InitSubmitAddForm();
	InitSubmitEditForm();
	InitEditorContent("#div_editor_detail_add", '#form_data_add [name="detail"]', "Nhập nội dung"); //Init Editor Add
});

function RenderHtml(data) {
	return `<div class="card m-0 h-100">
				<div class="row no-gutters h-100">
					<div class="col-md-4">
						<a  href="javascript:;" onclick="ShowViewModal(this,${data.id})">
							<img src="${data.imageObj?.relativeUrl ?? "/assets/images/empty-image.jpg"}" onclick="ShowViewModal(this,${data.id})" class="card-img h-100" style="object-fit: cover" alt="${data.title}">
						</a>
					</div>
					<div class="col-md-7">
						<div class="card-body d-flex flex-column h-100">
							<h5 class="card-title text-truncate-1" style="position: relative">
								${data.isHot === 1 ? '<span class="badge badge badge-info" style="position: absolute; font-size: 10px; right: 0; padding-bottom: 1px;">Hot</span>' : ''}
								<a  href="javascript:;" onclick="ShowViewModal(this,${data.id})" title="${data.title}">${data.title ?? ""}</a>
							</h5>
							<p class="card-text flex-grow-1 text-justify text-truncate-4">${data.description ?? "..."}</p>
							<p class="card-text d-flex justify-content-between mt-3">
								<small class="text-muted d-flex align-items-baseline">
									<i class="bx bx-user  mr-1"></i>
									<span>${data.createdBy ?? ""}</span>
								</small>
								<small class="text-muted d-flex align-item-baseline">
									<i class="bx bx-calendar mr-1"></i>
									<span>${moment(data.publishedAt).format('YYYY-MM-DD') ?? ""}</span>
								</small>
								${data.status ?
			`<small class="d-flex align-item-baseline badge badge-pill badge-success pt-1">
									<i class="bx bx-lock-open-alt  mr-1"></i>
									<span>Kích hoạt</span>
								</small>`
			:
			`<small class="d-flex align-item-baseline badge badge-pill badge-danger pt-1">
									<i class="bx bx-lock-alt  mr-1"></i>
									<span>Khóa</span>
								</small>`}
							</p>
						</div>
					</div>
					<div class="col-md-1 col-absolute">
						<div class="dropleft"  title="Thao tác">
							<button type="button" class="btn btn-sm dropdown-toggle col-btn-action" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
								<i class="bx bx-dots-vertical"></i>
							</button>
							<div class="dropdown-menu rounded shadow-sm border">
								<a class="dropdown-item d-flex align-items-center" href="javascript:;" onclick="ShowEditModal(this,${data.id})">
									<i class="bx bx-edit-alt"></i>
									<span class="font-13 ml-1">Cập nhật</span>
								</a>
								<div class="dropdown-divider"></div>
								<a class="dropdown-item d-flex align-items-center ${data.status ? "text-warning" : "text-success"}" href="javascript:;" onclick="ChangeStatus(this, event, ${data.status}, ${data.id}, '${data.timer}')">
									<i class="bx bx-lock-alt" style="height: 15px"></i>
									<span class="font-13 ml-1">${data.status ? "Khóa" : "Kích hoạt"}</span>
								</a>
								<div class="dropdown-divider"></div>
								<a class="dropdown-item d-flex align-items-center text-danger" href="javascript:;" onclick="ShowDeleteModal(${data.id})">
									<i class="bx bx-trash-alt" style="height: 15px"></i>
									<span class="font-13 ml-1">Xóa</span>
								</a>
							</div>
						</div>
					</div>
				</div>
			</div>`;
}

//Load data
function LoadData(method = 'GET', params) {
	laddaSearch.start();
	$.ajax({
		type: method,
		url: '/AboutManage/GetList',
		data: params,
		dataType: 'json',
		success: function (response) {
			laddaSearch.stop();
			if (!CheckResponseIsSuccess(response)) return false; let html = '';
			$.map(response.data, function (item) {
				html += `<div class="col-12 col-lg-6 col-xl-6 mb-4" id="div_item_${item.id}">${RenderHtml(item)}</div>`;
			});
			$('#div_main_content').html(html);
		},
		error: function (err) {
			CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
		}
	})
}

//Search
function Search() {
	LoadData('GET', {
		status: $selectSearchStatus.val()
	});
}

//Show panel when done
function ShowPanelWhenDone(html) {
	$(window).scrollTop();
	$('#div_view_panel').html(html);
	ShowHidePanel("#div_view_panel", "#div_main_card");
}

//Reset form
function ResetForm(formElm) {
	$(formElm).trigger('reset');
	$(formElm).find(".dropify-clear").trigger("click");
	RemoveClassValidate(formElm);
}

//Show add modal
function ShowAddModal() {
	ResetForm('#form_data_add');
	ShowHidePanel("#div_add_panel", "#div_main_card");
	ScrollToTop('#div_add_panel', 0, 200);
}

//Show edit modal
function ShowEditModal(elm, id) {
	let text = $(elm).html();
	$(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
	$.get(`/AboutManage/P_Edit/${id}`).done(function (response) {
		$(elm).attr('disabled', false); $(elm).html(text);
		if (!CheckResponseIsSuccess(response)) return false;
		RawUIFormEdit(response.data, '#form_data_edit');
		$('#div_edit_panel').find('#header_edit_title').text(`#${response.data.id} - ${response.data.title ?? ''}`);
		ShowHidePanel('#div_edit_panel', '#div_main_card');
		ScrollToTop('#div_edit_panel', 0, 200);
	}).fail(function (err) {
		$(elm).attr('disabled', false); $(elm).html(text);
		CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
	});
}

//Raw UI form edit
function RawUIFormEdit(res, formElm) {
	ResetForm(formElm);
	let $form = $(formElm);
	Object.keys(res).forEach((item, index, arr) => {
		$form.find(`[name="${item}"]`).val(res[item]);
	});
	$form.find('[name="isHot"]').attr('checked', res.isHot === 1 ? true : false);
	$form.find('[name="publishedAt"]').val(IsNullOrEmty(res.publishedAt) ? '' : moment(res.publishedAt).format('YYYY-MM-DD'));
	$form.find('#edit_image').attr('src', res.imageObj?.relativeUrl ?? '/images/error-image.png');

	InitEditorContent("#div_editor_detail_edit", '#form_data_edit [name="detail"]', "Nhập nội dung"); //Init Editor
}

//Show view modal
function ShowViewModal(elm, id) {
	let text = $(elm).html();
	$(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
	$.get(`/AboutManage/P_View/${id}`).done(function (response) {
		$(elm).attr('disabled', false); $(elm).html(text);
		if (response.result === -1 || response.result === 0) {
			CheckResponseIsSuccess(response); return false;
		}
		let $panel = $('#div_view_panel');
		$panel.find('#header_view_title').text(`#${response.data.id}`);
		$panel.find('#view_title').text(response.data.title ?? '');
		$panel.find('#view_description').text(response.data.description ?? '');
		$panel.find('#view_detail').html(response.data.detail ?? '');
		$panel.find('#view_link_ref').text(response.data.linkRef ?? '');
		$panel.find('#view_link_ref').attr('src', response.data.linkRef ?? '');
		$panel.find('#view_created_by').text(response.data.createdBy ?? '');
		$panel.find('#view_created_at').text(IsNullOrEmty(response.data.createdAt) ? '' : moment(response.data.createdAt).format('HH:mm DD/MM/YYYY'));
		$panel.find('#view_created_by').text(response.data.updatedBy ?? '');
		$panel.find('#view_updated_at').text(IsNullOrEmty(response.data.updatedAt) ? '' : moment(response.data.updatedAt).format('HH:mm DD/MM/YYYY'));
		$panel.find('#view_image').attr('src', response.data.imageObj?.relativeUrl ?? '/images/error-image.png');

		ShowHidePanel('#div_view_panel', '#div_main_card');
		ScrollToTop('#div_view_panel', 0, 200);
	}).fail(function (err) {
		$(elm).attr('disabled', false); $(elm).html(text);
		CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
	});
}

//Show delete modal
function ShowDeleteModal(id) {
	Swal.fire({
		title: "Bạn chắc chắn muốn xóa mục này?",
		text: " Không thể khôi phục sau khi xóa.",
		type: "question",
		showCancelButton: !0,
		cancelButtonText: "Hủy",
		confirmButtonText: "Đồng ý",
		cancelButtonClass: "btn btn-pinterest m-2 px-4 font-14",
		confirmButtonClass: "btn btn-linkedin m-2 px-4 font-14",
		buttonsStyling: !1,
		preConfirm: function () {
			Delete(id);
			Swal.fire({
				title: "!",
				text: "You clicked the button!",
				type: "success",
				confirmButtonClass: "btn btn-confirm mt-2"
			})
		}
	})
}

//Init submit add form
function InitSubmitAddForm() {
	$('#form_data_add').on('submit', function (e) {
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_add'));
		laddaSubmitForm.start();
		e.preventDefault();
		/*e.stopImmediatePropagation();*/
		let $formElm = $('#form_data_add');
		let isvalidate = CheckValidationUnobtrusive($formElm);
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		formData.set("isHot", $formElm.find('[name="isHot"]').eq(0).is(':checked') ? true : false);
		$.ajax({
			url: '/AboutManage/P_Add',
			type: 'POST',
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.AddSuccess);
				BackToTable('#div_main_card', '#div_add_panel');
				let html = `<div class="col-12 col-lg-6 col-xl-6 mb-4" id="div_item_${response.data.id}">${RenderHtml(response.data)}</div>`;
				$('#div_main_content').prepend(html);
			}, error: function (err) {
				laddaSubmitForm.stop();
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	});
}

//Init submit add form
function InitSubmitEditForm() {
	$('#form_data_edit').on('submit', function (e) {
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_edit'));
		laddaSubmitForm.start();
		e.preventDefault();
		/*e.stopImmediatePropagation();*/
		let $formElm = $('#form_data_edit');
		let isvalidate = CheckValidationUnobtrusive($formElm);
		if (!isvalidate) { laddaSubmitForm.stop(); ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		formData.set("isHot", $formElm.find('[name="isHot"]').eq(0).is(':checked') ? true : false);
		$.ajax({
			url: '/AboutManage/P_Edit',
			type: 'POST',
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.UpdateSuccess);
				BackToTable('#div_main_card', '#div_edit_panel');
				$(`#div_item_${response.data.id}`).html(RenderHtml(response.data));
			}, error: function (err) {
				laddaSubmitForm.stop();
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	});
}

//Change status
function ChangeStatus(elm, e, status, id, timer) {
	if ($(elm).data('clicked')) {
		e.preventDefault();
		e.stopPropagation();
	} else {
		$(elm).data('clicked', true);//Mark to ignore next click
		window.setTimeout(() => $(elm).removeData('clicked'), 800);//Unmark after time
		$(elm).attr('onclick', "event.preventDefault();");
		$('#status_' + id).parent().find('label.btn-active').attr('onclick', 'event.preventDefault()');
		$.ajax({
			type: 'POST',
			url: '/AboutManage/ChangeStatus',
			data: {
				id: id,
				status: status,
				timer: timer
			},
			dataType: 'json',
			success: function (response) {
				if (!CheckResponseIsSuccess(response)) {
					$(elm).attr('onclick', `ChangeStatus(this, event, ${id}, '${timer}')`); return false;
				}
				ShowToastNoti('success', '', _resultActionResource.UpdateStatusSuccess);
				window.setTimeout(function () {
					$(elm).attr('onclick', `ChangeStatus(this, event, ${response.data.id}, '${response.data.timer}')`);
					Search();
				}, 500);
			}, error: function (err) {
				$(elm).attr('onclick', `ChangeStatus(this, event, ${id}, '${timer}')`);
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	}
}

//Delete
function Delete(id) {
	$.ajax({
		type: 'POST',
		url: '/AboutManage/Delete',
		data: { id: id },
		dataType: 'json',
		success: function (response) {
			if (!CheckResponseIsSuccess(response)) return false;
			ShowToastNoti('success', '', _resultActionResource.DeleteSuccess);
			$(`#div_item_${id}`).fadeOut(200);
			setTimeout(function () {
				$(`#div_item_${id}`).remove();
			}, 400);
		},
		error: function (err) {
			CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
		}
	});
}

//Show hide panel image upload and view
function ShowHideImageUploadAndView(elm) {
	if ($('#div_view_image_edit').attr('style') != "display: none;") {
		$(elm).removeClass('bx bx-upload').addClass('bx bx-left-arrow-alt');
		ShowHidePanel("#div_upload_image_edit", "#div_view_image_edit");
	} else {
		$(elm).removeClass('bx bx-left-arrow-alt').addClass('bx bx-upload');
		ShowHidePanel("#div_view_image_edit", "#div_upload_image_edit");
	}
}