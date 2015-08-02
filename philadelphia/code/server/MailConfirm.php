<?php

require_once 'Db.php';
require_once 'SendMail.php';

	class MailConfirm 
	{
		public $db;
		public $mailer;

		public function __construct()
		{
			$this->db=new Db();
			$this->mailer=new MailSender();
			$this->salt1="sdretf";
			$this->salt2="54fsds";
		}

		public function sendConfirmationMail($applicant)
		{
			$serverUrl = 'www.toci.com.pl';
			//$serverUrl = 'localhost';
			
			$signature=$this->CreateSignature($applicant['email']);
			$confirmLink="http://".$serverUrl."/server/confirm.php?signature=$signature";
			$subject="Potwierdzenie woli uczestnictwa w szkoleniu TOCI";
			$message="Aby potwierdzić swoj adres e-mail kliknij w poniższy odnośnik. Wiadomość została wygenerowana automatycznie, nie ma konieczności odpowiadania na nią. <br>".$confirmLink;

			$result=$this->mailer->SendMail($subject,$message,$applicant['email'],$applicant['name']);

			return $result ? $signature : false;

		}

		public function CreateSignature($mail)
		{
			return md5($this->salt1.$mail.$this->salt2.microtime(true));
		}

		public function Verify($sign)
		{
			/// get from db

			// updaye e ten mail jest potwierdzony
		}
	}