<?php

	class NotImportantLogic
	{
		/**
		 * Whatever
		 * @var bool
		 */
		public $IAmNotImportant;
		
		/**
		 * Dafaq
		 * @var int
		 */
		private $IWouldLikeToBeImportant;
		
		/**
		 * wtf
		 * @var string
		 */
		protected $WhyAreTheyNotImportant;
		
		/**
		 * 
		 * Enter description here ...
		 * @param int $candidateId
		 */
		public function IAmAMethodCandidate($candidateId)
		{
			if ($candidateId > 5)
			{
				if ($this->IAmNotImportant)
				{
					foreach ($this->IWouldLikeToBeImportant as $key => $value)
					{
						$this->IAmAMethodCandidate(6);
					}
				}
			}
			
			//preg_grep($pattern, $input)
		}
	}