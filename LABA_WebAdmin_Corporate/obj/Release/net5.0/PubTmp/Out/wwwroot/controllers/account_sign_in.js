var laddaSubmitForm;

$(document).ready(function () {

	//Init ladda
	laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form'));
	//Submit form
	$('#form_data').on('submit', function (e) {
		e.preventDefault();
		/*   e.stopImmediatePropagation();*/
		let $formElm = $('#form_data');
		let isvalidate = $formElm[0].checkValidity();
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); return false; }
		let formData = new FormData($formElm[0]);
		laddaSubmitForm.start();
		$.ajax({
			url: $formElm.attr('action'),
			type: $formElm.attr('method'),
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (response.result === 3) { //Is unAuthen
					ShowToastNoti('error', '', 'Bạn không có quyền đăng nhập hệ thống!');
				} else if (response.result === 1) { //Is success
					ShowToastNoti('success', '', 'Đăng nhập . Đang chuyển hướng...');
					location.href = IsNullOrEmty(response.data) ? "/" : response.data;
				} else { //Fail
					CheckResponseIsSuccess(response);
				}
			}, error: function (err) {
				laddaSubmitForm.stop();
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	});

});

function ShowPassword(elm) {
	var pass = $(elm).parent('.input-group').find('input[name="password"]');
	if ($(pass).attr('type') === "password") {
		$(pass).attr('type', 'text');
		$(elm).find('#password_show').hide();
		$(elm).find('#password_hide').show();
	} else {
		$(pass).attr('type', 'password');
		$(elm).find('#password_show').show();
		$(elm).find('#password_hide').hide();
	}
}