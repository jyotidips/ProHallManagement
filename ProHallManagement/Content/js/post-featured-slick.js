	$(document).ready(function() {
		"use strict";

       /*================== App Gallery =====================*/
        $('.post-featured-slick').slick({
		  centerMode: true,
		  centerPadding: '320px',
		  slidesToShow: 1,
		  responsive: [
		  	{
		      breakpoint: 1200,
		      settings: {
		        arrows: false,
		        centerMode: true,
		        centerPadding: '150px',
		        slidesToShow: 1
		      }
		    },
		    {
		      breakpoint: 980,
		      settings: {
		        arrows: false,
		        centerMode: true,
		        centerPadding: '50px',
		        slidesToShow: 1
		      }
		    },
		    {
		      breakpoint: 767,
		      settings: {
		        arrows: false,
		        centerMode: true,
		        centerPadding: '0',
		        slidesToShow: 1
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
		        arrows: false,
		        centerMode: true,
		        centerPadding: '0',
		        slidesToShow: 1
		      }
		    }
		  ]
		});

	});