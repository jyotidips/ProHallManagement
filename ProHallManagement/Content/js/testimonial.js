$(document).ready(function() {
		"use strict";
		
		$('.slider-for').slick({
		  slidesToShow: 1,
		  slidesToScroll: 1,
		  arrows: false,
		  slide: 'li',
		  fade: false,
		  asNavFor: '.slider-nav'
		});
		$('.slider-nav').slick({
		  slidesToShow: 5,
		  slidesToScroll: 1,
		  asNavFor: '.slider-for',
		  dots: false,
		  arrows: false,
		  slide: 'li',
		  vertical: false,
		  centerMode: true,
		  centerPadding: '0px',
		  focusOnSelect: true,
		  responsive: [
		    {
		      breakpoint: 1200,
		      settings: {
		        slidesToShow: 3,
		        slidesToScroll: 1,
		        infinite: true,
		        vertical: false,
		        centerMode: true,
		        centerPadding: '115px',
		        dots: false
		      }
		    },
		    {
		      breakpoint: 980,
		      settings: {
		        slidesToShow: 3,
		        slidesToScroll: 1,
		        infinite: true,
		        vertical: false,
		        centerMode: true,
		        centerPadding: '115px',
		        dots: false
		      }
		    },
		    {
		      breakpoint: 767,
		      settings: {
		        slidesToShow: 3,
		        slidesToScroll: 1,
		        infinite: true,
		        vertical: false,
		        centerMode: true,
		        centerPadding: '70px',
		        dots: false
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
		        slidesToShow: 3,
		        slidesToScroll: 1,
		        infinite: true,
		        vertical: false,
		        centerMode: true,
		        centerPadding: '60px',
		        dots: false
		      }
		    }
		  ]
		});

});