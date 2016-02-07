<?php

	class ConvertionManager implements IConvertionManager
	{
		/**
		 * prog language ie c#
		 * @var ClassDefinitionContainer
		 */
		protected $ProgramingLanguage;
		
		/**
		 * Full class definition
		 * @var ClassDefinitionContainer
		 */
		protected $classDefinitionContainer;
		
		/**
		 * Convert
		 * @param array $inputPaths
		 * @param array $outputPaths
		 * @return string code after convertion
		 */
		public function Convert($inputPaths, $outputPaths, $srcLang, $destLAng)
		{
			// open files 
			// foreach
			// convert  ConvertFromText
		}
		
		//virtual pod override
		protected function ConvertFromText($codeString, $outputFileName, $srcLang, $destLAng)
		{
			// return IClassDefinitionContainer->serialize
			// string new code
		}
		
		protected function Save($codeString, $outputFileName, $outputCodeString)
		{
			
		}
	} 