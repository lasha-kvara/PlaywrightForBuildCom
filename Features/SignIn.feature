Feature: SignIn
    Log In Scenarios
    
    @Test @PositiveScenario
Scenario: LogIn Successfully
   Given Go To Login Page
   Then Enter Email "sometestemail@gmail.com"
   Then Enter Password "testpassword123"
   And Click Login Button
   Then Verify Login Successful
   
   @Test @NegativeScenario
Scenario Template: Login - Invalid User Validations
   Given Go To Login Page
   Then Enter Email "<invalidEmail>"
   Then Enter Password "<invalidPassword>"
   And Click Login Button
   Then Verify Invalid Email Or Password Error Message
   
   Examples: 
   | invalidEmail           | invalidPassword    |
   | invalidemail@email.com | InvalidPassword123 |
   | invalidemail@some.com  | invalidPass        |
   