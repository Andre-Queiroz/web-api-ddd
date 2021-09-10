using Manager.API.ViewModels;

namespace Manager.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Ocorreu algum erro interno na aplicação.",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Os dados de login estão incorrretos.",
                Success = false,
                Data = null
            };
        }




    }
}