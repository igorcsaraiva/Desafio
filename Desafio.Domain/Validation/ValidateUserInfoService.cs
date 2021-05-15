using Desafio.Domain.Domain;
using Desafio.Domain.Interfaces;
using System.Collections.Generic;

namespace Desafio.Domain.Validation
{
    public class ValidateUserInfoService : IValidateUserInfo
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public ValidateUserInfoService(IUserInfoRepository userInfoRepository) => _userInfoRepository = userInfoRepository;

        public ValidationResponse ValidateAddition(UserInfo Obj)
        {
            var msg = new List<string>(3);

            if (string.IsNullOrEmpty(Obj.HomeTown) && string.IsNullOrEmpty(Obj.Name) && string.IsNullOrEmpty(Obj.UserId))
                msg.Add("properties cannot be null or empty");
            if (string.IsNullOrWhiteSpace(Obj.HomeTown) && string.IsNullOrWhiteSpace(Obj.Name) && string.IsNullOrWhiteSpace(Obj.UserId))
                msg.Add("properties cannot be null or empty space");
            if (_userInfoRepository.ObjExist(Obj))
                msg.Add("This user already has information added, consider editing them");

            if (msg.Count > 0)
                return new ValidationResponse { Message = "One or more validation errors occurred.", Erros = msg };

            return new ValidationResponse();
        }

        public ValidationResponse ValidateEdit(UserInfo Obj)
        {
            var msg = new List<string>(3);

            if (string.IsNullOrEmpty(Obj.HomeTown) && string.IsNullOrEmpty(Obj.Name) && string.IsNullOrEmpty(Obj.UserId))
                msg.Add("properties cannot be null or empty");
            if (string.IsNullOrWhiteSpace(Obj.HomeTown) && string.IsNullOrWhiteSpace(Obj.Name) && string.IsNullOrWhiteSpace(Obj.UserId))
                msg.Add("properties cannot be null or empty space");
            if (_userInfoRepository.ObjExist(Obj) is not true)
                msg.Add("This userInfo does not exist");

            if (msg.Count > 0)
                return new ValidationResponse { Message = "One or more validation errors occurred.", Erros = msg };

            return new ValidationResponse { Message = "no errors found" };
        }

        public ValidationResponse ValidateRemoval(UserInfo Obj)
        {
            var msg = new List<string>(1);

            if (_userInfoRepository.ObjExist(Obj) is not true)
                msg.Add("This userInfo does not exist");

            if (msg.Count > 0)
                return new ValidationResponse { Message = "One or more validation errors occurred.", Erros = msg };

            return new ValidationResponse { Message = "no errors found" };
        }

    }
}
