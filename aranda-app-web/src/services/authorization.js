export const ValidateAuthorization = (permissions = [], userPermissions = []) => {
    console.log(permissions,userPermissions);
    const response = permissions.filter(x => userPermissions.includes(x));
    if(response.length > 0){
        return true;
    }
    return false;
}