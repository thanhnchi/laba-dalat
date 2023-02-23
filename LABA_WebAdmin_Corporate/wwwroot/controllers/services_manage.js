var laddaSubmitForm;
var dataTable;
var $tableMain = $('#table_main');
var $selectSearchStatus = $('#select_search_status'),
	$selectSearchCategory = $('#select_search_category');
var laddaSearch = Ladda.create(document.querySelector('#btn_search'));
const DEFAULT_OPTION = '<option value="">Tất cả</option>';

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
		LoadDataTable();
	}, 100)
	GetListDropdownNewsCategory();
	//Init submit form
	InitSubmitAddForm();
	InitSubmitEditForm();
	InitEditorContent("#div_editor_detail_add", '#form_data_add [name="detail"]', "Nhập nội dung"); //Init Editor Add
});

const buttonActionHtml = function (id, status, timer) {
	let html = ``;
	html += `<a href="javascript:void(0);" class="action-icon font-20" onclick="ShowEditModal(this,${id})" title="${_buttonResource.Edit}">${_iconEditHtml}</a>`;
	html += `<a href="javascript:void(0);" class="action-icon font-20 mx-1" onclick="ShowDeleteModal(this,${id})" title="${_buttonResource.Delete}">${_iconDeleteHtml}</a> `;
	if (parseInt(status) !== -1)
		html += `<div class="custom-control custom-switch" style="position: initial; display: inline;">
                  <input type="checkbox" class="custom-control-input custom-control-input-success" id="status_${id}" ${parseInt(status) == 0 ? "" : "checked"} onclick="ChangeStatus(this, event, '${id}', '${timer}')">
                  <label class="custom-control-label" for="status_${id}"></label>
                </div>`;
	return `<div class="d-flex justify-content-between align-items-center">${html}</div>`;
}
const statusHtml = function (status) {
	let html = '';
	switch (parseInt(status)) {
		case 0: html = `<span class="badge badge-warning">${_textOhterResource.lock}</span>`; break;
		case 1: html = `<span class="badge badge-success">${_textOhterResource.active}</span>`; break;
		default: break;
	}
	return html;
}

const dataParamsTable = function (method = 'GET') {
	return {
		type: method,
		url: '/ServicesManage/GetList',
		data: function (d) {
			d.status = $selectSearchStatus.val(),
				d.categoryId = $selectSearchCategory.val()
		},
		dataType: 'json',
		beforeSend: function () {
			laddaSearch.start();
		},
		dataSrc: function (response) {
			laddaSearch.stop();
			if (CheckResponseIsSuccess(response) && response.data != null)
				return response.data;
			return [];
		},
		error: function (err) {
			laddaSearch.stop();
			CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			return [];
		}
	};
}
const columnTable = function () {
	return [
		{
			title: "STT",
			data: null,
			render: (data, type, row, meta) => ++meta.row,
			className: "text-center"
		},
		{
			data: "imageObj",
			render: (data, type, row, meta) => `<img class="border p-1" src="${data?.smallUrl ?? ''}" style="width:60px;height:60px;object-fit:cover;" alt="avatar" ${_imageErrorUrl.square}' />`,
			className: "text-center text-nowrap",
		},
		{
			data: "title",
			render: (data, type, row, meta) => `<div style="position: relative;">${row.isHot === 1 ? '<span class="badge badge badge-info" style="position: absolute; left: -5px; bottom: 100%; padding-bottom: 1px;">Hot</span>' : ''}<a class="table_a_href text-truncate-2 font-13" onclick="ShowViewModal(this, '${row.id}')" href="javascript:void(0);" title="${data}">${data ?? ''}</a></div>`,
			className: "text-nowrap",
		},
		{
			data: "description",
			render: (data, type, row, meta) => `<p class="text-truncate-4 mb-0  font-13" title="${data}">${data ?? ''}</p>`,
			className: "text-wrap",
		},
		{
			data: "categoryObj",
			render: (data, type, row, meta) => `<p class="mb-0  font-13" title="${data}">${data.name ?? ''}</p>`,
			className: "text-nowrap",
		},
		{
			data: "status",
			render: (data, type, row, meta) => statusHtml(data),
			className: "text-center text-nowrap",
		},
		{
			data: "publishedAt",
			render: (data, type, row, meta) => `<p class="mb-0 font-13">${IsNullOrEmty(data) ? '' : moment(data).format('YYYY-MM-DD')}</p>`,
			className: "text-center text-nowrap",
		},
		{
			data: "createdAt",
			render: (data, type, row, meta) => `<p class="mb-0 font-13">${IsNullOrEmty(data) ? '' : moment(data).format('YYYY-MM-DD')}</p>`,
			className: "text-center text-nowrap",
			visible: false,
		},
		{
			data: "updatedAt",
			render: (data, type, row, meta) => `<p class="mb-0 font-13">${IsNullOrEmty(data) ? '' : moment(data).format('YYYY-MM-DD')}</p>`,
			className: "text-center text-nowrap",
			visible: false,
		},
		{
			data: "id",
			render: (data, type, row, meta) => buttonActionHtml(data, row.status, row.timer),
			orderable: false,
			searchable: false,
			className: "text-center text-nowrap"
		},
	];
}

//Get list dropdown news category
function GetListDropdownNewsCategory() {
	$.ajax({
		type: 'GET',
		url: '/Common/GetListDropdownServicesCategory',
		data: { typeId: 0 },
		dataType: 'json',
		success: function (response) {
			if (!CheckResponseIsSuccess(response)) return false;
			let optionHtml = '';
			$.map(response.data, function (item) {
				optionHtml += `<option value="${item.id}">${item.name}</option>`;
			});
			$('form [name="newsCategoryId"]').html(optionHtml);
			$('form [name="newsCategoryId"]').selectpicker("refresh");
			let firstOption = $('form [name="newsCategoryId"]').children('option:not(.bs-title-option)').eq(0).val();
			$('form [name="newsCategoryId"]').selectpicker("val", firstOption);

			$selectSearchCategory.html(DEFAULT_OPTION + optionHtml);
			$selectSearchCategory.selectpicker("refresh");
			let firstSearchOption = $selectSearchCategory.children('option:not(.bs-title-option)').eq(0).val();
			$selectSearchCategory.selectpicker("val", firstSearchOption);
		},
		error: function (err) {
			CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
		}
	});
}

//Load table
function LoadDataTable(method = 'GET') {
	if (dataTable) dataTable.ajax.reload(null, true);
	dataTable = $tableMain.DataTable({
		lengthChange: true,
		lengthMenu: _lengthMenuResource,
		colReorder: { allowReorder: false },
		select: false,
		scrollX: true,
		stateSave: false,
		processing: true,
		responsive: { details: true },
		ajax: dataParamsTable(method),
		rowId: "id",
		columns: columnTable(),
		language: _languageDataTalbeObj,
		drawCallback: _dataTablePaginationStyle,
		initComplete: function () { jQuery(jQuery.fn.dataTable.tables(true)).DataTable().columns.adjust().draw(); }
	});
}

//Search 
function Search() {
	LoadDataTable();
}

//Show panel when done
function ShowPanelWhenDone(html) {
	$(window).scrollTop();
	$('#div_view_panel').html(html);
	ShowHidePanel("#div_view_panel", "#div_main_table");
}

//Reset form
function ResetForm(formElm) {
	$(formElm).trigger('reset');
	$(formElm).find(".dropify-clear").trigger("click");
	let firstOptionCategoryId = $('form [name="categoryId"]').children('option:not(.bs-title-option)').eq(0).val();
	$('form [name="categoryId"]').selectpicker("refresh");
	$('form [name="categoryId"]').selectpicker("val", firstOptionCategoryId);
	let firstOptionIsHot = $(formElm).find('[name="isHot"]').children('option:not(.bs-title-option)').eq(0).val();
	$(formElm).find('[name="isHot"]').selectpicker("refresh");
	$(formElm).find('[name="isHot"]').selectpicker("val", firstOptionIsHot);
	RemoveClassValidate(formElm);
}

//Show add modal
function ShowAddModal() {
	ResetForm('#form_data_add');
	ShowHidePanel("#div_add_panel", "#div_main_table");
	ScrollToTop('#div_add_panel', 0, 200);
	$('#div_add_panel .navbar_title').addClass('active');
}

//Show edit modal
function ShowEditModal(elm, id) {
	let text = $(elm).html();
	$(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
	$.get(`/ServicesManage/P_Edit/${id}`).done(function (response) {
		$(elm).attr('disabled', false); $(elm).html(text);
		if (!CheckResponseIsSuccess(response)) return false;
		RawUIFormEdit(response.data, '#form_data_edit');
		$('#div_edit_panel').find('#header_edit_title').text(`#${response.data.id} - ${response.data.title ?? ''}`);
		ShowHidePanel('#div_edit_panel', '#div_main_table');
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
	$form.find('[name="newsCategoryId"]').selectpicker("refresh");
	$form.find('[name="newsCategoryId"]').selectpicker("val", res.newsCategoryId);
	$form.find('[name="publishedAt"]').val(IsNullOrEmty(res.publishedAt) ? '' : moment(res.publishedAt).format('YYYY-MM-DD'));
	$form.find('#edit_image').attr('src', res.imageObj?.relativeUrl ?? '/images/error-image.png');

	InitEditorContent("#div_editor_detail_edit", '#form_data_edit [name="detail"]', "Nhập nội dung"); //Init Editor
}

//Show view modal
function ShowViewModal(elm, id) {
	let text = $(elm).html();
	$(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
	$.get(`/ServicesManage/P_View/${id}`).done(function (response) {
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
		$panel.find('#view_created_at').text(IsNullOrEmty(response.data.createdAt) ? '' : moment(response.data.createdAt).format('HH:mm DD/MM/YYYY'));
		$panel.find('#view_updated_at').text(IsNullOrEmty(response.data.updatedAt) ? '' : moment(response.data.updatedAt).format('HH:mm DD/MM/YYYY'));
		$panel.find('#view_image').attr('src', response.data.imageObj?.relativeUrl ?? '/images/error-image.png');

		ShowHidePanel('#div_view_panel', '#div_main_table');
		ScrollToTop('#div_view_panel', 0, 200);
	}).fail(function (err) {
		$(elm).attr('disabled', false); $(elm).html(text);
		CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
	});
}

//Show delete modal
function ShowDeleteModal(elm, id) {
	$(elm).attr('disabled', true);
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
	setTimeout(() => $(elm).attr('disabled', false), 500);
}

//Delete
function Delete(id) {
	$.ajax({
		type: 'POST',
		url: '/ServicesManage/Delete',
		data: { id: id },
		dataType: 'json',
		success: function (response) {
			$('#modal_delete').modal('hide');
			if (!CheckResponseIsSuccess(response)) return false;
			ShowToastNoti('success', '', _resultActionResource.DeleteSuccess);
			ChangeUIDelete(dataTable, id);
		},
		error: function (err) {
			CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
		}
	});
}

//Init submit add form
function InitSubmitAddForm() {
	$('#form_data_add').on('submit', function (e) {
		e.preventDefault();
		/*e.stopImmediatePropagation();*/
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_add'));
		laddaSubmitForm.start();
		let $formElm = $('#form_data_add');
		//let isvalidate = $formElm[0].checkValidity();
		let isvalidate = CheckValidationUnobtrusive($formElm);
		let categoryId = $formElm.find('[name="newsCategoryId"]').val();
		if (IsNullOrEmty(categoryId) || categoryId == 0) { ShowToastNoti('warning', '', 'Loại tin chưa được chọn!'); return false; }
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		formData.set("isHot", $formElm.find('[name="isHot"]').eq(0).is(':checked') ? true : false);
		$.ajax({
			url: '/ServicesManage/P_Add',
			type: 'POST',
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.AddSuccess);
				BackToTable('#div_main_table', '#div_add_panel');
				ResetForm('#form_data_add');
				if (CheckNewRecordIsAcceptAddTable(response.data)) ChangeUIAdd(dataTable, response.data); //Add row in table
			}, error: function (err) {
				laddaSubmitForm.stop();
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	});
}

//Init submit edit form
function InitSubmitEditForm() {
	$('#form_data_edit').on('submit', function (e) {
		e.preventDefault();
		/*	e.stopImmediatePropagation();*/
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_add'));
		laddaSubmitForm.start();
		let $formElm = $('#form_data_edit');
		let isvalidate = CheckValidationUnobtrusive($formElm);
		let categoryId = $formElm.find('[name="newsCategoryId"]').val();
		if (IsNullOrEmty(categoryId) || categoryId == 0) { ShowToastNoti('warning', '', 'Loại tin chưa được chọn!'); return false; }
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		formData.set("isHot", $formElm.find('[name="isHot"]').eq(0).is(':checked') ? true : false);
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_edit'));
		laddaSubmitForm.start();
		$.ajax({
			url: '/ServicesManage/P_Edit',
			type: 'POST',
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.UpdateSuccess);
				BackToTable('#div_main_table', '#div_edit_panel');
				ResetForm('#form_data_edit');
				ChangeUIEdit(dataTable, response.data.id, response.data);
			}, error: function (err) {
				laddaSubmitForm.stop();
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	});
}

//Change status
function ChangeStatus(elm, e, id, timer) {
	if ($(elm).data('clicked')) {
		e.preventDefault();
		e.stopPropagation();
	} else {
		$(elm).data('clicked', true);//Mark to ignore next click
		window.setTimeout(() => $(elm).removeData('clicked'), 800);//Unmark after time
		$(elm).attr('onclick', "event.preventDefault();");
		$('#status_' + id).parent().find('label.btn-active').attr('onclick', 'event.preventDefault()');
		var isChecked = $('#status_' + id).is(":checked");
		$.ajax({
			type: 'POST',
			url: '/ServicesManage/ChangeStatus',
			data: {
				id: id,
				status: isChecked ? 1 : 0,
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
					ChangeUIEdit(dataTable, response.data.id, response.data);
				}, 500);
			}, error: function (err) {
				$(elm).attr('onclick', `ChangeStatus(this, event, ${id}, '${timer}')`);
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	}
}

//Check new record isvalid
function CheckNewRecordIsAcceptAddTable(data) {
	let condition = true; //place condition expression in here
	return condition;
}

//Show hide panel image upload and view
function ShowHideImageUploadAndView(elm) {
	if ($('#div_view_image_edit').attr('style') != "display: none;") {
		$(elm).removeClass('fa-upload').addClass('fa-arrow-left');
		ShowHidePanel("#div_upload_image_edit", "#div_view_image_edit");
	} else {
		$(elm).removeClass('fa-arrow-left').addClass('fa-upload');
		ShowHidePanel("#div_view_image_edit", "#div_upload_image_edit");
	}
}

// Upload Image
function ShowHideImageUploadAndView(elm) {
	if ($('#div_view_image_edit').attr('style') != "display: none;") {
		$(elm).removeClass('bx bx-upload').addClass('bx bx-left-arrow-alt');
		ShowHidePanel("#div_upload_image_edit", "#div_view_image_edit");
	} else {
		$(elm).removeClass('bx bx-left-arrow-alt').addClass('bx bx-upload');
		ShowHidePanel("#div_view_image_edit", "#div_upload_image_edit");
	}
}