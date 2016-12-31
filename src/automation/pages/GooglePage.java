package automation.pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.WebDriverWait;

public class GooglePage {

    WebDriver driver;

    @FindBy(name = "q")
    WebElement querySearch;

    WebDriverWait wait;

    public GooglePage(WebDriver driver) {
        this.driver = driver;
        wait = new WebDriverWait(driver, 10);
        //This initElements method will create all WebElements
        PageFactory.initElements(driver, this);
    }

    public void search(String searchText) {
        querySearch.clear();
        querySearch.sendKeys(searchText);
        querySearch.submit();
        waitForTile(searchText);
    }

    public void waitForTile(final String title) {
        wait.until(new ExpectedCondition<Boolean>() {
            public Boolean apply(WebDriver d) {
                return d.getTitle().toLowerCase().startsWith(title.toLowerCase());
            }
        });
    }
}
