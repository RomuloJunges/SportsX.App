using System;
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

        public async Task<PhoneDTO[]> AddPhone(PhoneDTO[] model)
        {
            try
            {
                var phones = _mapper.Map<Phone[]>(model);
                if (phones == null) return null;

                _genericPersist.AddRange<Phone>(phones);

                if (await _genericPersist.SaveChangesAsync())
                {
                    var result = await _phonePersist.GetPhonesByUserAsync(phones[0].UserId);
                    return _mapper.Map<PhoneDTO[]>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhoneDTO[]> UpdatePhone(PhoneDTO[] model)
        {
            try
            {
                var phones = _mapper.Map<Phone[]>(model);
                if (phones == null) return null;

                _genericPersist.UpdateRange<Phone>(phones);

                if (await _genericPersist.SaveChangesAsync())
                {
                    var result = await _phonePersist.GetPhonesByUserAsync(phones[0].UserId);
                    return _mapper.Map<PhoneDTO[]>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePhone(Guid phoneId)
        {
            try
            {
                var phone = await _phonePersist.GetPhoneByIdAsync(phoneId);
                if (phone == null) throw new Exception("Phone to delete not found");

                _genericPersist.Delete<Phone>(phone);
                return await _genericPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhoneDTO[]> GetPhonesByUserIdAsync(Guid userId)
        {
            try
            {
                var phones = await _phonePersist.GetPhonesByUserAsync(userId);
                if (phones == null) return null;

                var result = _mapper.Map<PhoneDTO[]>(phones);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhoneDTO> GetPhoneByIdAsync(Guid id)
        {
            try
            {
                var phone = await _phonePersist.GetPhoneByIdAsync(id);
                if (phone == null) return null;

                var result = _mapper.Map<PhoneDTO>(phone);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}