# Onyx Solution
This application get the products based on API calls

### BusinessApi:
To call the secured apis, user will need to pass the header values for an API Key:
Header Key: onyx-auth-key
Header Value: D8958E77254A439EA36E079BDB9A9E7C

Description:
1. I have used an API key approach for the API calls.
image.png


Key (D8958E77254A439EA36E079BDB9A9E7C) can be found in the appSetting.json also:
To filter by colors, API call can be done for below colors, any other color name will return empty result:
"Blue", "Pink", "Purple", "Orange", "Golden", "Yellow", "Red", "Crimson", "Gray"

All API URLs:
1. https://localhost:7021/
2. https://localhost:7021/api/Product
3. https://localhost:7021/api/Product/Gray


NOTE: Since I am not using any DB end to save/retrieve data, the API key and products are hardcoded in the C# code.
