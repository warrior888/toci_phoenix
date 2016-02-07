<?php

	abstract class ClassDefinitionContainerBase implements IClassDefinitionContainer
	{
		public abstract function Serialize($sourceCodeString, $sourceProgramingLanguage, $destinationProgramingLanguage);
		
		protected function GetConvertionManager($srcLang, $destLang)
		{
			// TODO
			return new PHPToCSharpConvertionDefinitionContainer();
		}
	}