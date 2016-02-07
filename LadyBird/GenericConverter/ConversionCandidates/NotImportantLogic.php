<?php

	class NotImportantLogic
	{
		public $IAmNotImportant;
		private $IWouldLikeToBeImportant;
		protected $WhyAreTheyNotImportant;
		
		public function IAmAMethodCandidate($candidateId)
		{
			if ($candidateId > 5)
			{
				if ($this->IAmNotImportant)
				{
					foreach ($this->IWouldLikeToBeImportant as $key => $value)
					{
						
					}
				}
			}
		}
	}