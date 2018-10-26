	$(document).ready(function() {
		"use strict";

		/*================== App Gallery =====================*/
        $('#slide-post-carousel-sec').slick({
		  centerMode: false,
		  centerPadding: '0px',
		  slidesToShow: 3,
		  arrows: false,
		  responsive: [
		    {
		      breakpoint: 980,
		      settings: {
		        arrows: false,
		        centerMode: true,
		        centerPadding: '0px',
		        slidesToShow: 2
		      }
		    },
		    {
		      breakpoint: 767,
		      settings: {
		        arrows: false,
		        centerMode: false,
		        centerPadding: '0',
		        slidesToShow: 2
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
		        arrows: false,
		        centerMode: false,
		        centerPadding: '0',
		        slidesToShow: 1
		      }
		    }
		  ]
		});

	});