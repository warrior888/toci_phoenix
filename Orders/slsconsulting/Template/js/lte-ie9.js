$(document).ready(function(){
	if($('.met_portfolio_row .span6:nth-child(2n + 1)').length > 0){
		$('.met_portfolio_row .span6:nth-child(2n + 1)').addClass('nth-child-2np1');
	}
	if($('.met_portfolio_row .span4:nth-child(3n + 1)').length > 0){
		$('.met_portfolio_row .span4:nth-child(3n + 1)').addClass('nth-child-3np1');
	}
});