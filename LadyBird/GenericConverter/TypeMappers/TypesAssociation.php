<?php

	class TypesAssociation
	{
		/**
		array(1,2,3,4,5,6, 
				'klucz' => array(
					'alamakota' => 8,
					array('jezusmaria')
				)
			)
		 */
		
		protected $typeMap = 
		array(
			'array' 	=> 'Dictionary<{KeyPlaceHolder}, {ValuePlaceHolder}>',
			'int' 		=> 'int',
			'string' 	=> 'string',
		);
		
		public function GetTypesAssociation() // wszystkie
		{
			
		}
		
		public function GetTypeAssociation($associationTypeId)
		{
			
		}
	}