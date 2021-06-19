using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SportsX.Application.Contracts;
using SportsX.Application.DTOs;
using SportsX.Domain;
using SportsX.Persistence.Contracts;

namespace SportsX.Application
{
    public class PhoneService : IPhoneService
    {
        private readonly IGenericPersist _genericPersist;
        private readonly IPhonePersist _phonePersist;
        private readonly IMapper _mapper;

        public PhoneService(IGenericPersist genericPersist, IPhonePersist phonePersist, IMapper mapper)
        {
            this._mapper = mapper;
            this._phonePersist = phonePersist;
            this._genericPersist = genericPersist;
        }

        public async Task AddPhone(int userId, PhoneDTO model)
        {
            try
            {
                var phone = _mapper.Map<Phone>(model);
                phone.UserId = userId;

                _genericPersist.Add<Phone>(phone);

                await _genericPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PhoneDTO[]> SavePhone(int userId, PhoneDTO[] models)
        {
            try
            {
                var phones = await _phonePersist.GetPhonesByUserIdAsync(userId);
                if (phones == null) return null;

                foreach (var model in models)
                {
                    if (model.Id == 0)
                    {
                        await AddPhone(userId, model);
                    }
                    else
                    {
                        var phone = phones.FirstOrDefault(p => p.Id == model.Id);
                        model.UserId = userId;

                        _mapper.Map(model, phone);

                        _genericPersist.Update<Phone>(phone);

                        await _genericPersist.SaveChangesAsync();
                    }
                }

                var returnPhones = await _phonePersist.GetPhonesByUserIdAsync(userId);

                return _mapper.Map<PhoneDTO[]>(returnPhones);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePhone(int userId, int phoneId)
        {
            try
            {
                var phone = await _phonePersist.GetPhoneByIdsAsync(userId, phoneId);
                if (phone == null) throw new Exception("Phone para delete não encontrado");

                _genericPersist.Delete<Phone>(phone);
                return await _genericPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhoneDTO> GetPhoneByIdsAsync(int userId, int phoneId)
        {
            try
            {
                var phone = await _phonePersist.GetPhoneByIdsAsync(userId, phoneId);
                if (phone == null) return null;

                var returnPhone = _mapper.Map<PhoneDTO>(phone);

                return returnPhone;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhoneDTO[]> GetPhonesByUserIdAsync(int userId)
        {
            try
            {
                var phones = await _phonePersist.GetPhonesByUserIdAsync(userId);
                if (phones == null) return null;

                var returnPhones = _mapper.Map<PhoneDTO[]>(phones);

                return returnPhones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}