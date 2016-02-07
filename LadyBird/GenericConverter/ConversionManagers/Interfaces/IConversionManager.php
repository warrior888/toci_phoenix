<?php

	interface IConvertionManager
	{
		/**
		 * Convert
		 * @param array $inputPaths
		 * @param array $outputPaths
		 * @return string code after convertion
		 */
		function Convert($inputPaths, $outputPaths);
	}