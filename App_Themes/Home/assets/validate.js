/* <![CDATA[ */
// Jquery validate form contact
jQuery(document).ready(function(){

	$('#contactform').submit(function(){

		var action = $(this).attr('action');

		$("#message-contact").slideUp(750,function() {
		$('#message-contact').hide();

 		$('#submit-contact')
			.after('<img src="img/ajax-loader2.gif" class="loader" >')
			.attr('disabled','disabled');

		$.post(action, {
			name: $('#name').val(),
			email: $('#email').val(),
			phone: $('#phone').val(),
			comments: $('#comments').val(),
			institution:$('#institution').val(),
			verify_contact: $('#verify_contact').val()
		},
			function(data){
				document.getElementById('message-contact').innerHTML = data;
				$('#message-contact').slideDown('slow');
				$('#contactform img.loader').fadeOut('slow',function(){$(this).remove()});
				$('#submit-contact').removeAttr('disabled');
				if(data.match('success') != null) $('#contactform').slideUp('slow');

			}
		);

		});

		return false;

	});
		});


// Jquery validate plan a visit
jQuery(document).ready(function(){

	$('#visit').submit(function(){

		var action = $(this).attr('action');

		$("#message-visit").slideUp(750,function() {
		$('#message-visit').hide();

 		$('#submit-visit')
			.after('<img src="img/ajax-loader2.gif" class="loader" >')
			.attr('disabled','disabled');

		$.post(action, {
			name_visit: $('#name_visit').val(),
			lastname_visit: $('#lastname_visit').val(),
			email_visit: $('#email_visit').val(),
			phone_visit: $('#phone_visit').val(),
			date_visit: $('#date_visit').val(),
			verify_visit: $('#verify_visit').val()
		},
			function(data){
				document.getElementById('message-visit').innerHTML = data;
				$('#message-visit').slideDown('slow');
				$('#visit img.loader').fadeOut('slow',function(){$(this).remove()});
				$('#submit-visit').removeAttr('disabled');
				if(data.match('success') != null) $('#visit').slideUp('slow');

			}
		);

		});

		return false;

	});

});

			  

/// Jquery validate newsletter
jQuery(document).ready(function(){

	$('#newsletter').submit(function(){

		var action = $(this).attr('action');

		$("#message-newsletter").slideUp(750,function() {
		$('#message-newsletter').hide();
		
		$('#submit-newsletter')
			.after('<img src="img/ajax-loader2.gif" class="loader" >')
			.attr('disabled','disabled');

		$.post(action, {
			email_newsletter: $('#email_newsletter').val()
		},
			function(data){
				document.getElementById('message-newsletter').innerHTML = data;
				$('#message-newsletter').slideDown('slow');
				$('#newsletter img.loader').fadeOut('slow',function(){$(this).remove()});
				$('#submit-newsletter').removeAttr('disabled');
				if(data.match('success') != null) $('#newsletter').slideUp('slow');

			}
		);

		});

		return false;

	});

});
  /* ]]> */