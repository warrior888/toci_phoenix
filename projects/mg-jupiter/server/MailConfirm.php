<?php

	class MailConfirm 
	{
		$salt = 'fnduwoghwoghweoghwghwdiguohwergo';

		public function CreateSignature($mail)
		{
			$signature = md5($mail.$this->salt.date('h:i:s'));

			// save to db signature
			//generate link confirm.php?signature=$signature

			// wsylac na $mail
		}

		public function Verify($sign)
		{
			/// get from db

			// updaye e ten mail jest potwierdzony
		}
	}