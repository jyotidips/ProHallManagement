$(document).ready(function() {
		"use strict";

		/*================== App Gallery =====================*/
        $('#post-wide-carousel').slick({
		  centerMode: false,
		  centerPadding: '0px',
		  slidesToShow: 1,
		  arrows: false,
		  responsive: [
		    {
		      breakpoint: 980,
		      settings: {
		        arrows: false,
		        centerMode: true,
		        centerPadding: '0px',
		        slidesToShow: 1
		      }
		    },
		    {
		      breakpoint: 767,
		      settings: {
		        arrows: false,
		        centerMode: false,
		        centerPadding: '0',
		        slidesToShow: 1
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