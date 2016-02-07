<?php

	class ClassDefinitionContainer extends ClassDefinitionContainerBase implements IClassDefinitionContainer
	{
		/**
		 * Name of the class
		 * @var string
		 */
		public $ClassName;
		
		public $ClassMethods; // array 
		
		public $ClassDefinitionVariables;
		
		/**
		 * Generate new class in new language
		 * @param $sourceCodeString
		 * @param $programingLanguage
		 * @return string $result
		 */
		public function Serialize($sourceCodeString, $sourceProgramingLanguage, $destinationProgramingLanguage)
		{
			return $this->GetConvertionManager($sourceProgramingLanguage, $destinationProgramingLanguage)->
				Serialize($sourceCodeString, $sourceProgramingLanguage, $destinationProgramingLanguage);
		}
	}