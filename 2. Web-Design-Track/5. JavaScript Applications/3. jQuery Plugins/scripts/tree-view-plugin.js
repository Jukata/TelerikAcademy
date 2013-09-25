(function($) {
  $.fn.treeView = function(options) {
	if(!options) options = {};
	var speed = options.speed || 1000;
	var element = $(this.selector);
	
	$('ul', element).addClass('hidden').hide();
	$('ul', element).parent().addClass('has-child');
	$('li a', element).on('click', function(){
		var target = $(this).next('ul');
		
		if(target.hasClass('hidden')){
			target.removeClass('hidden');
			target.show(speed);
		}
		else{
			target.addClass('hidden');
			target.hide(speed);
		}
	});
	return element;
  }
}(jQuery))