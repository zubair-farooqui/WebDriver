package automation.tests;

import automation.pages.GooglePage;
import org.junit.*;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import java.io.File;

public class GoogleTests {

    static WebDriver driver;

    @BeforeClass
    public static void initialize() {
        File file = new File("G:\\Work\\WebDriver\\chromedriver.exe");
        System.setProperty("webdriver.chrome.driver", file.getAbsolutePath());
        driver = new ChromeDriver();
    }

    @Before
    public void setup() {
        driver.get("http://www.google.com");
    }

    @Test
    public void testCheese() {
        GooglePage google = new GooglePage(driver);
        google.search("Cheese");
        Assert.assertEquals("Cheese - Google Search", driver.getTitle());
        System.out.println("Page title is: " + driver.getTitle());
    }

    @Test
    public void testBread() {
        GooglePage google = new GooglePage(driver);
        google.search("Bread");
        Assert.assertEquals("Bread - Google Search", driver.getTitle());
        System.out.println("Page title is: " + driver.getTitle());
    }

    @AfterClass
    public static void tearDown() {
        driver.quit();
    }
}
