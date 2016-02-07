<?php

	abstract class Instruction implements IInstruction
	{
		public $Text; // for (;;) 
		
		public $Instructions; // array of what is inside for/foreach/while loop
	}