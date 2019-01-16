package br.com.k21.cenarios;

import org.fluentlenium.adapter.FluentTest;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import cucumber.api.java.pt.*;

public class CenarioEmitirEtiqueta extends FluentTest  {

	private WebDriver driver;
	
	@Dado("^que eu estou na pagina do enderecador$")
	public void que_eu_estou_na_pagina_do_enderecador() throws Throwable {		
		driver = new ChromeDriver();
		
		driver.navigate().to("http://correios.com.br");		
		driver.findElement(By.cssSelector("#content-principais-servicos > ul > li:nth-child(6) > a")).click();		
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > p:nth-child(4) > a:nth-child(1)")).click();;
	}

	@Quando("^eu preencher os dados da tela$")
	public void eu_preencher_os_dados_da_tela() throws Throwable {
		preencherCEP_Remetente("82030340");
		
		preencherNomeEPromocao_Remetente("Dina S/A", "promo");
	
		preencherNumero_Remetente("165");
		
		
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(4) > label > input[type='text']:nth-child(3)")).sendKeys("80002900");
	
		driver.findElement(By.cssSelector("body")).click();
		
		WebDriverWait wait = new WebDriverWait(driver, 30);
		wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")));
				
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(6) > label > input")).sendKeys("Blá Blá Blá");
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(7) > label > input")).sendKeys("Promo");
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(10) > label > input")).sendKeys("100");		
	}

	@Quando("^clicar no botao$")
	public void clicar_no_botao() throws Throwable {
		driver.findElement(By.cssSelector("#btGerarEtiquetas")).click();
	}

	@Entao("^a etiqueta deve ser emitida$")
	public void a_etiqueta_deve_ser_emitida() throws Throwable {
	    driver.close();
	    driver.quit();
	}
	
	private void preencherNumero_Remetente(String numero) {
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(8) > label > input")).sendKeys(numero);
	}

	private void preencherNomeEPromocao_Remetente(String nome, String promo) {
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")).sendKeys(nome);
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(5) > label > input")).sendKeys(nome);
	}

	private void preencherCEP_Remetente(String cep) {
		driver.findElement(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > p > span > label > input[type='text']:nth-child(2)")).sendKeys(cep);
		driver.findElement(By.cssSelector("body")).click();
		
		WebDriverWait wait = new WebDriverWait(driver, 30);
		wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")));
		
	}
}