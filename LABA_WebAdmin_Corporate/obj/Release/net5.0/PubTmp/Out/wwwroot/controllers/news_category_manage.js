var laddaSubmitForm;
var dataTable;
var $tableMain = $('#table_main');
var $selectSearchStatus = $('#select_search_status');
var laddaSearch = Ladda.create(document.querySelector('#btn_search'));
const DEFAULT_OPTION = '<option value="0">--Chọn--</option>';

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
	//Init table
	LoadDataTable();

	//Init submit form
	//$.Components.init(); //Init form validation
	InitSubmitAddForm();
	InitSubmitEditForm();
});

const buttonActionHtml = function (id, status, timer) {
	let html = ``;
	html += `<a href="javascript:void(0);" class="action-icon font-20" onclick="ShowEditModal(this,${id})" title="${_buttonResource.Edit}">${_iconEditHtml}</a>`;
	html += `<a href="javascript:void(0);" class="action-icon font-20" onclick="ShowDeleteModal(this,${id})" title="${_buttonResource.Delete}">${_iconDeleteHtml}</a> `;
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
		url: '/NewsCategoryManage/GetList',
		data: function (d) {
			d.status = $selectSearchStatus.val()
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
			render: (data, type, row, meta) => `<a onclick="ShowViewModal(this, '${row.id}')" href="javascript:void(0);"><img class="img img-thumbnail" src="${data?.smallUrl ?? ''}" style="width:60px;height:60px;object-fit:cover;" alt="avatar" ${_imageErrorUrl.square}' /></a>`,
			className: "text-center text-nowrap",
		},
		{
			data: "name",
			render: (data, type, row, meta) => `<a class="table_a_href" onclick="ShowViewModal(this, '${row.id}')" href="javascript:void(0);">${data}</a>`,
		},
		{
			data: "description",
			render: (data, type, row, meta) => `<p class="text-truncate-2 mb-0" title="${data}">${data ?? ''}</p>`,
			className: "text-wrap",
		},
		{
			data: "reOrder",
			render: (data, type, row, meta) => data,
			className: "text-center text-nowrap",
		},
		{
			data: "status",
			render: (data, type, row, meta) => statusHtml(data),
			className: "text-center text-nowrap",
		},
		{
			data: "createdAt",
			render: (data, type, row, meta) => IsNullOrEmty(data) ? '' : moment(data).format('DD-MM-YYYY'),
			className: "text-center text-nowrap",
		},
		{
			data: "publishedAt",
			render: (data, type, row, meta) => IsNullOrEmty(data) ? '' : moment(data).format('DD-MM-YYYY'),
			className: "text-center text-nowrap",
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

function ShowPanelWhenDone(html, elm) {
	$(elm).html(html);
	$(elm).modal("show");
}
function HidePanelWhenDone(elm) {
	setTimeout(function () {
		$(elm).modal("hide");
	}, 500)
}

// Init Upload File
function InitUploadFile(elm) {
	$(elm).dropify({
		messages: {
			default: "Chọn ảnh đại diện",
			replace: "Chọn ảnh khác",
			remove: '<i class="bx bx-trash-alt"></i>',
			error: "Có lỗi vui lòng chọn ảnh khác.",
		},
		tpl: {
			message: '<div class="dropify-message"><span class="bx bx-upload font-40"></span> <p class="font-14">{{ default }}</p></div>',
			clearButton: '<button type="button" class="dropify-clear btn btn-danger p-1">{{ remove }}</button>',
		},
		error: {
			fileSize: "Vượt quá kích thước cho phép ({{ value }} max).",
			minWidth: "The image width is too small ({{ value }}}px min).",
			maxWidth: "The image width is too big ({{ value }}}px max).",
			minHeight: "The image height is too small ({{ value }}}px min).",
			maxHeight: "The image height is too big ({{ value }}px max).",
			imageFormat: "Định dạng không đưuọc cho phép ({{ value }} only).",
		},
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

//Reset form
function ResetForm(formElm) {
	$(formElm).trigger('reset');
	$(formElm).find(".dropify-clear").trigger("click");
	RemoveClassValidate(formElm);
}

//Show add modal
function ShowAddModal(elm) {
	ResetForm('#form_data_add');
	$('#modal_add').modal('show');
}

//Show edit modal
function ShowEditModal(elm, id) {
	let text = $(elm).html();
	$(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
	$.get(`/NewsCategoryManage/P_Edit/${id}`).done(function (response) {
		$(elm).attr('disabled', false); $(elm).html(text);
		if (!CheckResponseIsSuccess(response)) return false;
		let $form = $('#form_data_edit');
		ResetForm($($form));
		Object.keys(response.data).forEach((item, index, arr) => {
			$form.find(`[name="${item}"]`).val(response.data[item]);
		});
		RawUIFormEdit(response.data, '#form_data_edit');
		$('#modal_edit').modal('show');
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
	$form.find('#edit_image').attr('src', res.imageObj?.relativeUrl ?? '/images/error-image.png');

	InitEditorContent("#div_editor_detail_edit", '#form_data_edit [name="detail"]', "Nhập nội dung"); //Init Editor
}

//Show view modal
function ShowViewModal(elm, id) {
	let text = $(elm).html();
	$(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
	$.get(`/NewsCategoryManage/P_View/${id}`).done(function (response) {
		$(elm).attr('disabled', false); $(elm).html(text);
		if (response.result === -1 || response.result === 0) {
			CheckResponseIsSuccess(response); return false;
		}
		let $panel = $('#modal_view');

		$panel.find('#header_view_title').text(`#${response.data.id} - ${response.data.name}`);
		$panel.find('#view_name').text(response.data.name ?? '');
		$panel.find('#view_description').text(response.data.description ?? '');
		$panel.find('#view_order').text(response.data.reOrder);
		$panel.find('#view_status').html(`${response.data.status === 1 ? '<span class="badge badge-success">Mở</span>' : '<span class="badge badge-danger">Khoá</span>'}`);
		$panel.find('#view_created_at').text(IsNullOrEmty(response.data.createdAt) ? '' : moment(response.data.createdAt).format('HH:mm DD/MM/YYYY'));
		$panel.find('#view_created_by').text(IsNullOrEmty(response.data.createdBy) ? '' : response.data.createdBy);
		$panel.find('#view_updated_at').text(IsNullOrEmty(response.data.updatedAt) ? '' : moment(response.data.updatedAt).format('HH:mm DD/MM/YYYY'));
		$panel.find('#view_updated_by').text(IsNullOrEmty(response.data.updatedBy) ? '' : response.data.updatedBy);
		$panel.find('#view_image').attr('src', response.data.imageObj?.relativeUrl ?? '/images/error-image.png');

		$panel.modal('show');
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
		url: '/NewsCategoryManage/Delete',
		data: { id: id },
		dataType: 'json',
		success: function (response) {
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
		let $formElm = $('#form_data_add');
		//let isvalidate = $formElm[0].checkValidity();
		let isvalidate = CheckValidationUnobtrusive($formElm);
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_add'));
		laddaSubmitForm.start();
		$.ajax({
			url: '/NewsCategoryManage/P_Add',
			type: 'POST',
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.AddSuccess);
				HidePanelWhenDone('#modal_add');
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
		/*e.stopImmediatePropagation();*/
		let $formElm = $('#form_data_edit');
		//let isvalidate = $formElm[0].checkValidity();
		let isvalidate = CheckValidationUnobtrusive($formElm);
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form_edit'));
		laddaSubmitForm.start();
		$.ajax({
			url: '/NewsCategoryManage/P_Edit',
			type: 'POST',
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.UpdateSuccess);
				HidePanelWhenDone('#modal_edit')
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
			url: '/NewsCategoryManage/ChangeStatus',
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