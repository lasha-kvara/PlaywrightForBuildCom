Feature: Products
Products Tests
    
    @Test @PositiveScenario
Scenario Template: Verify Product Price
    Given Search Product Named "<productNameOrId>"
    Then Verify That Product Card Are Visible
    And Verify Product "<productNameOrId>" Price Should Be $<productPrice>
    
    Examples: 
    | productNameOrId | productPrice |
    | bci2296636      | 189.95       |
    | bci3753881      | 271.67       |
    
    @Test @PositiveScenario
Scenario: Verify API
    Given Search Product Named "<productNameOrId>"
    Then bearer
    Then Test API
    