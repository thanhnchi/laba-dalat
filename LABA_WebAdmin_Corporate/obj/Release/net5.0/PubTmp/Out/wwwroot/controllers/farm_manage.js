const FIRST_OPTION = '<option value="0">--Chọn--</option>';

$(document).ready(function () {
	ShowImageMessage($('#form_data #img_logo'));
	ShowImageMessage($('#form_data #img_favicon'));
	ShowImageMessage($('#form_data #img_qrcode'));

	//Submit form
	$('#form_data').on('submit', function (e) {
		laddaSubmitForm = Ladda.create(document.querySelector('#btn_submit_form'));
		laddaSubmitForm.start();
		e.preventDefault();
		/*e.stopImmediatePropagation();*/

		let $formElm = $('#form_data');
		let isvalidate = CheckValidationUnobtrusive($formElm);
		if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); laddaSubmitForm.stop(); return false; }
		let formData = new FormData($formElm[0]);
		formData.set('addressObj.latitude', parseFloat($formElm.find('[name="addressObj.latitude"]').val()));
		formData.set('addressObj.longitude', parseFloat($formElm.find('[name="addressObj.longitude"]').val()));
		$.ajax({
			url: '/FarmManage/P_Edit',
			type: $formElm.attr('method'),
			data: formData,
			contentType: false,
			processData: false,
			success: function (response) {
				laddaSubmitForm.stop();
				if (!CheckResponseIsSuccess(response)) return false;
				ShowToastNoti('success', '', _resultActionResource.UpdateSuccess);

				//Update new data
				$formElm.find('[name="imageId"]').val(response.data.imageId);
				$formElm.find('[name="imageFavicon"]').val(response.data.imageFavicon);
				$formElm.find('[name="imageQrcode"]').val(response.data.imageQrcode);
				$formElm.find('[name="timer"]').val(response.data.timer);
				$formElm.find('[name="addressId"]').val(response.data.addressId);
				$formElm.find('[name="addressObj.id"]').val(response.data.addressObj?.id);
				$formElm.find('[name="addressObj.timer"]').val(response.data.addressObj?.timer);

			}, error: function (err) {
				laddaSubmitForm.stop();
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	});
})

//Show Image Message
function ShowImageMessage(imgElm) {
	if (!$(imgElm).attr('src')) {
		$(imgElm).parent().find('span.message_img').text('Không có hình ảnh!');
	} else {
		$(imgElm).parent().find('span.message_img').text('');
	}
}

//Upload Image
function UploadImage(inputElm, imgElm) {
	$(inputElm).on('change', function () {
		imageUploadUrl = URL.createObjectURL(event.target.files[0])
		$(imgElm).fadeIn("fast").attr('src', imageUploadUrl);

		ShowImageMessage(imgElm);
	})
	$(inputElm).trigger('click');
}

//Remove Image
function RemoveImage(inputElm, imgElm, formInputElm) {
	if (!$(imgElm).attr('src')) {
		ShowToastNoti('warning', '', 'Không thể xóa ảnh trống !')
	} else {
		Swal.fire({
			title: "Xác nhận xóa ảnh?",
			text: "Bạn chắc chắn muốn muốn xóa ảnh!",
			type: "question",
			showCancelButton: !0,
			cancelButtonText: "Hủy",
			confirmButtonText: "Đồng ý",
			cancelButtonClass: "btn btn-pinterest m-2 px-4 font-14",
			confirmButtonClass: "btn btn-linkedin m-2 px-4 font-14",
			buttonsStyling: !1,
			preConfirm: function () {
				$(inputElm).val('');
				$(imgElm).attr('src', '');
				$(formInputElm).val('');

				ShowImageMessage(imgElm);
			}
		})
	}
}

//Raw html button full screen map
function RawHtmlButtonFullScreen(controlDiv, map) {
	// Set CSS for the control border.
	const controlUI = document.createElement("div");

	controlUI.style.backgroundColor = "#fff";
	controlUI.style.border = "2px solid #fff";
	controlUI.style.borderRadius = "3px";
	controlUI.style.boxShadow = "0 2px 6px rgba(0,0,0,.3)";
	controlUI.style.cursor = "pointer";
	controlUI.style.marginRight = "10px";
	controlUI.style.marginTop = "2px";
	controlUI.style.marginBottom = "8px";
	controlUI.style.textAlign = "center";
	controlUI.title = "Open fullscreen Map";
	controlUI.setAttribute("data-current", "normal");
	controlDiv.appendChild(controlUI);

	// Set CSS for the control interior.
	const controlText = document.createElement("div");

	controlText.style.color = "rgb(25,25,25)";
	controlText.style.padding = "9px";
	controlText.innerHTML = '<img src="data:image/svg+xml,%3Csvg%20xmlns%3D%22http%3A//www.w3.org/2000/svg%22%20viewBox%3D%220%200%2018%2018%22%3E%3Cpath%20fill%3D%22%23666%22%20d%3D%22M0%200v6h2V2h4V0H0zm16%200h-4v2h4v4h2V0h-2zm0%2016h-4v2h6v-6h-2v4zM2%2012H0v6h6v-2H2v-4z%22/%3E%3C/svg%3E" alt="" style="height: 18px; width: 18px;">';
	controlUI.appendChild(controlText);

	// Setup the click event listeners: simply set the map to Chicago.
	controlUI.addEventListener("click", () => { //Zoom in
		if (controlUI.getAttribute("data-current") == "normal") {
			controlText.innerHTML = '<img src="data:image/svg+xml,%3Csvg%20xmlns%3D%22http%3A//www.w3.org/2000/svg%22%20viewBox%3D%220%200%2018%2018%22%3E%3Cpath%20fill%3D%22%23666%22%20d%3D%22M4%204H0v2h6V0H4v4zm10%200V0h-2v6h6V4h-4zm-2%2014h2v-4h4v-2h-6v6zM0%2014h4v4h2v-6H0v2z%22/%3E%3C/svg%3E" alt="" style="height: 18px; width: 18px;">';
			controlUI.title = "Exit fullscreen Map";
			controlUI.setAttribute("data-current", "full");
			$('#map').addClass('fullscreen');
			document.getElementsByTagName("body")[0].style.overflow = "hidden";
			document.getElementById("pac-card").style.width = "400px";
		} else { //Zoom out
			controlText.innerHTML = '<img src="data:image/svg+xml,%3Csvg%20xmlns%3D%22http%3A//www.w3.org/2000/svg%22%20viewBox%3D%220%200%2018%2018%22%3E%3Cpath%20fill%3D%22%23666%22%20d%3D%22M0%200v6h2V2h4V0H0zm16%200h-4v2h4v4h2V0h-2zm0%2016h-4v2h6v-6h-2v4zM2%2012H0v6h6v-2H2v-4z%22/%3E%3C/svg%3E" alt="" style="height: 18px; width: 18px;">';
			controlUI.title = "Open fullscreen Map";
			controlUI.setAttribute("data-current", "normal");
			$('#map').removeClass('fullscreen');
			document.getElementsByTagName("body")[0].style.overflow = "";
			document.getElementById("pac-card").style.width = "auto";
		}
	});
}

//Init Map
function initMap(lat = 0, lng = 0) {
	let latVal = IsNullOrEmty($('#Latitude').val()) ? 14.058324 : $('#Latitude').val(); //default location vn
	let lngVal = IsNullOrEmty($('#Longitude').val()) ? 108.277199 : $('#Longitude').val(); //default location vn
	var thisLocation = {
		lat: parseFloat(latVal),
		lng: parseFloat(lngVal)
	};
	$('#gps-lat').html(thisLocation.lat);
	$('#gps-lng').html(thisLocation.lng);

	const map = new google.maps.Map(document.getElementById("map"), {
		center: thisLocation,
		zoom: 15,
		mapTypeControl: true,
		mapTypeControlOptions: {
			style: google.maps.MapTypeControlStyle.DROPDOWN_MENU, // DROPDOWN_MENU HORIZONTAL_BAR
			position: google.maps.ControlPosition.LEFT_TOP,
		},
		scaleControl: true,
		streetViewControl: true,
		fullscreenControl: false,
		//fullscreenControlOptions: {
		//    position: google.maps.ControlPosition.LEFT_BOTTOM,
		//},
	});

	const fullScreenDiv = document.createElement("div");

	RawHtmlButtonFullScreen(fullScreenDiv, map);

	map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(fullScreenDiv);

	const card = document.getElementById("pac-card");
	const input = document.getElementById("pac-input");
	map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);
	const autocomplete = new google.maps.places.Autocomplete(input);
	// Bind the map's bounds (viewport) property to the autocomplete object,
	// so that the autocomplete requests use the current map bounds for the
	// bounds option in the request.
	autocomplete.bindTo("bounds", map);
	// Set the data fields to return when the user selects a place.
	autocomplete.setFields([
		"address_components",
		"geometry",
		"icon",
		"name",
	]);
	const infowindow = new google.maps.InfoWindow();
	const infowindowContent = document.getElementById("infowindow-content");
	infowindow.setContent(infowindowContent);

	//Set marker location
	var marker = new google.maps.Marker({
		map,
		position: thisLocation,
		anchorPoint: new google.maps.Point(0, -29),
	});

	//Set event click map marker
	map.addListener('click', function (mapsMouseEvent) {
		marker.setMap(null);
		marker = new google.maps.Marker({
			position: mapsMouseEvent.latLng,
			map: map
		});
		$('#gps-lat').html(mapsMouseEvent.latLng.lat());
		$('#gps-lng').html(mapsMouseEvent.latLng.lng());
		$('#Latitude').val(mapsMouseEvent.latLng.lat());
		$('#Longitude').val(mapsMouseEvent.latLng.lng());
		$('#pac-input').val("");
		ShowToastNoti('info', '', `${mapsMouseEvent.latLng.lat()}, ${mapsMouseEvent.latLng.lng()}`, 1000, 'topCenter');
	});

	//auto complelte search
	autocomplete.addListener("place_changed", () => {
		infowindow.close();
		marker.setVisible(false);
		const place = autocomplete.getPlace();

		if (!place.geometry) {
			// User entered the name of a Place that was not suggested and
			// pressed the Enter key, or the Place Details request failed.
			ShowToastNoti('info', '', "Không tìm thấy: " + place.name);
			//window.alert(
			//    "No details available for input: '" + place.name + "'"
			//);
			return;
		}

		// If the place has a geometry, then present it on a map.
		if (place.geometry.viewport) {
			map.fitBounds(place.geometry.viewport);
		} else {
			map.setCenter(place.geometry.location);
			map.setZoom(17); // Why 17? Because it looks good.
		}
		marker.setPosition(place.geometry.location);
		marker.setVisible(true);
		let address = "";

		if (place.address_components) {
			address = [
				(place.address_components[0] &&
					place.address_components[0].short_name) ||
				"",
				(place.address_components[1] &&
					place.address_components[1].short_name) ||
				"",
				(place.address_components[2] &&
					place.address_components[2].short_name) ||
				"",
			].join(" ");
		}
		infowindowContent.children["place-icon"].src = place.icon;
		infowindowContent.children["place-name"].textContent = place.name;
		infowindowContent.children["place-address"].textContent = address;
		infowindow.open(map, marker);
		$('#gps-lat').html(place.geometry.location.lat());
		$('#gps-lng').html(place.geometry.location.lng());
		$('#Latitude').val(place.geometry.location.lat());
		$('#Longitude').val(place.geometry.location.lng());
	});

	// Sets a listener on a radio button to change the filter type on Places
	// Autocomplete.
	function setupClickListener(id, types) {
		const radioButton = document.getElementById(id);
		radioButton.addEventListener("click", () => {
			autocomplete.setTypes(types);
		});
	}
	setupClickListener("changetype-all", []);
	setupClickListener("changetype-address", ["address"]);
	setupClickListener("changetype-establishment", ["establishment"]);
	setupClickListener("changetype-geocode", ["geocode"]);
	document
		.getElementById("use-strict-bounds")
		.addEventListener("click", function () {
			console.log("Checkbox clicked! New state=" + this.checked);
			autocomplete.setOptions({ strictBounds: this.checked });
		});
}

// Load Province
function LoadProvince(elm, divElm, formElm) {
	const FIRST_OPTION = '<option value="0">--Chọn--</option>';
	let value = $(elm).val();
	let $provinceSelect = $(formElm).find('[name="addressObj.provinceId"]');
	let $districtSelect = $(formElm).find('[name="addressObj.districtId"]');
	let $wardSelect = $(formElm).find('[name="addressObj.wardId"]');

	$districtSelect.html(FIRST_OPTION);
	$districtSelect.val('0');
	//$districtSelect.selectpicker("refresh");
	//$districtSelect.selectpicker("val", 0);

	$wardSelect.html(FIRST_OPTION);
	//$wardSelect.selectpicker("refresh");
	//$wardSelect.selectpicker("val", 0);
	if (parseInt(value) === 0) {
		$provinceSelect.html(FIRST_OPTION);
		$provinceSelect.attr('disabled', true);
		//$provinceSelect.selectpicker("refresh");
		$districtSelect.html('');
		$districtSelect.attr('disabled', true);
		//$districtSelect.selectpicker("refresh");
		$wardSelect.html('');
		$wardSelect.attr('disabled', true);
		//$wardSelect.selectpicker("refresh");
		//$provinceSelect.selectpicker("val", 0);
	}
	else {
		ShowOverlay3Dot($(divElm));
		$.ajax({
			type: "GET",
			url: "/Common/GetListDropdownProvince",
			data: {
				countryId: value
			},
			dataType: 'json',
			success: function (response) {
				HideOverlay3Dot($(divElm));
				if (!CheckResponseIsSuccess(response)) return false;
				let html = '';
				$.map(response.data, function (item) {
					html += `<option value="${item.id}">${item.name}</option>`;
				});
				$provinceSelect.html(FIRST_OPTION + html);
				$provinceSelect.attr('disabled', false);
				$provinceSelect.val($provinceSelect.children('option:not(.bs-title-option)').eq(0).val());
				//$provinceSelect.selectpicker("refresh");
				//$provinceSelect.selectpicker("val", $provinceSelect.children('option:not(.bs-title-option)').eq(0).val());
			},
			error: function (err) {
				HideOverlay3Dot($(divElm));
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	}
}

// Load District
function LoadDistrict(elm, divElm, formElm) {
	let value = $(elm).val();
	let $districtSelect = $(formElm).find('[name="addressObj.districtId"]');
	let $wardSelect = $(formElm).find('[name="addressObj.wardId"]');

	$wardSelect.html(FIRST_OPTION);
	$wardSelect.val('0');
	//$wardSelect.selectpicker("refresh");
	//$wardSelect.selectpicker("val", 0);
	if (parseInt(value) === 0) {
		$districtSelect.html('');
		$districtSelect.attr('disabled', true);
		//$districtSelect.selectpicker("refresh");
		$wardSelect.html('');
		$wardSelect.attr('disabled', true);
		//$wardSelect.selectpicker("refresh");
		//$districtSelect.selectpicker("val", 0);
	} else {
		ShowOverlay3Dot($(divElm));
		$.ajax({
			type: "GET",
			url: "/Common/GetListDropdownDistrict",
			data: {
				provinceId: value
			},
			dataType: 'json',
			success: function (response) {
				HideOverlay3Dot($(divElm));
				if (!CheckResponseIsSuccess(response)) return false;
				let html = '';
				$.map(response.data, function (item) {
					html += `<option value="${item.id}">${item.name}</option>`;
				});
				$districtSelect.html(FIRST_OPTION + html);
				$districtSelect.attr('disabled', false);
				$districtSelect.val($districtSelect.children('option:not(.bs-title-option)').eq(0).val());
				//$districtSelect.selectpicker("refresh");
				//$districtSelect.selectpicker("val", $districtSelect.children('option:not(.bs-title-option)').eq(0).val());
				$wardSelect.html('');
				$wardSelect.attr('disabled', true);
				//$wardSelect.selectpicker("refresh");
			},
			error: function (err) {
				HideOverlay3Dot($(divElm));
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	}
}

// Load Ward
function LoadWard(elm, divElm, formElm) {
	let value = $(elm).val();
	let $wardSelect = $(formElm).find('[name="addressObj.wardId"]');
	if (parseInt(value) === 0) {
		$wardSelect.html('');
		$wardSelect.attr('disabled', true);
		//$wardSelect.selectpicker("refresh");
		//$wardSelect.selectpicker("val", 0);
	} else {
		ShowOverlay3Dot($(divElm));
		$.ajax({
			type: "GET",
			url: "/Common/GetListDropdownWard",
			data: {
				districtId: value
			},
			dataType: 'json',
			success: function (response) {
				HideOverlay3Dot($(divElm));
				if (!CheckResponseIsSuccess(response)) return false;
				let html = '';
				$.map(response.data, function (item) {
					html += `<option value="${item.id}">${item.name}</option>`;
				});
				$wardSelect.html(FIRST_OPTION + html);
				$wardSelect.attr('disabled', false);
				$wardSelect.val($wardSelect.children('option:not(.bs-title-option)').eq(0).val());
				//$wardSelect.selectpicker("refresh");
				//$wardSelect.selectpicker("val", $wardSelect.children('option:not(.bs-title-option)').eq(0).val());
			},
			error: function (err) {
				HideOverlay3Dot($(divElm));
				CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
			}
		});
	}
}
