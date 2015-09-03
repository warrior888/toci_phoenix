<?php
require_once (__DIR__.'/Mailer/PHPMailerAutoload.php');
require_once(__DIR__.'/config.php');


class MailSender{

	public $mail;

	public function MailSender()
	{
		$this->mail=new PHPMailer();
		$this->mail->isSMTP();
		$this->mail->SMTPDebug = SMTPDebug; // debugging: 1 = errors and messages, 2 = messages only
		$this->mail->SMTPAuth = SMTPAuth; // authentication enabled
		$this->mail->SMTPSecure = SMTPSecure; // secure transfer enabled REQUIRED for GMail
		$this->mail->Host = Host;
		$this->mail->Port = Port; // or 587
		$this->mail->IsHTML(IsHTML);
		$this->mail->Username = Username;
		$this->mail->Password = Password;
	}

	public function SendMail($subject, $message, $senderEmail)
	{

		$this->mail->Subject=$subject;
		$this->mail->Body=$message;
		$this->mail->AddAddress(SendFromEmail);
		$this->mail->SetFrom($senderEmail);

		return $this->mail->Send();
	}
}
