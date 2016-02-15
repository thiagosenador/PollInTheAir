// DATETIME PICKER

$(function () {
	$('#ExpirationDate').datetimepicker({
		minDate: moment().add(1, 'hour'),
		maxDate: moment().add(1, 'month'),
		locale: 'en-us',
		showClose: true
	});

	$("#datepickerIcon").click(function () {
		$('#ExpirationDate').data('DateTimePicker').show();
	});
});

// SLIDER

var initialRange = 50;

$(function () {

	$("#Range").ionRangeSlider({
		hide_min_max: true,
		keyboard: true,
		min: 20,
		max: 100,
		from: initialRange,
		type: 'single',
		step: 5,
		postfix: "m",
		grid: true,
		onChange: function (data) {
			UpdateCircle(data['from']);
		}
	});
});

// GOOGLE MAPS

var map;
var pos;
var circle;

function initMap() {
	map = new google.maps.Map(document.getElementById('map'), {
		center: { lat: -34.397, lng: 150.644 },
		zoom: 18,
		streetViewControl: false,
		mapTypeControl: false
	});

	// Try HTML5 geolocation.
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(
			function (position) {
				pos = {
					lat: position.coords.latitude,
					lng: position.coords.longitude
				};

				map.setCenter(pos);

				this.PlaceMarker();

				this.SetLatLongValues();

				this.DrawRange();
				this.UpdateCircle(initialRange);
			});
	}
}

function PlaceMarker() {
	var marker = new google.maps.Marker({
		position: pos,
		map: map,
		title: 'you are here!'
	});

	marker.setMap(map);
}

function SetLatLongValues() {
	$("#latitude").val(pos.lat);
	$("#longitude").val(pos.lng);
}

function DrawRange() {
	circle = new google.maps.Circle({
		strokeColor: '#FF0000',
		strokeOpacity: 0.8,
		strokeWeight: 1,
		fillColor: '#FF0000',
		fillOpacity: 0.35,
		map: map,
		center: pos
	});

	circle.setMap(map);
}

function UpdateCircle(radius) {
	circle.setRadius(radius);

	$("#Range").val(radius);
}